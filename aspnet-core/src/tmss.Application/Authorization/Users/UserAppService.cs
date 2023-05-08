using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Notifications;
using Abp.Organizations;
using Abp.Runtime.Session;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using tmss.Authorization.Users.Dto;
using tmss.Authorization.Users.Exporting;
using tmss.Dto;
using tmss.Url;

namespace tmss.Authorization.Users
{
    //[AbpAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UserAppService : tmssAppServiceBase, IUserAppService
    {
        public IAppUrlService AppUrlService { get; set; }

        private readonly IUserListExcelExporter _userListExcelExporter;
        private readonly IRepository<RolePermissionSetting, long> _rolePermissionRepository;
        private readonly IRepository<UserPermissionSetting, long> _userPermissionRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IUserPolicy _userPolicy;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRoleManagementConfig _roleManagementConfig;
        private readonly UserManager _userManager;
        public UserAppService(
            IUserListExcelExporter userListExcelExporter,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IRepository<RolePermissionSetting, long> rolePermissionRepository,
            IRepository<UserPermissionSetting, long> userPermissionRepository,
            IRepository<UserRole, long> userRoleRepository,
            IUserPolicy userPolicy,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            IPasswordHasher<User> passwordHasher,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRoleManagementConfig roleManagementConfig,
            UserManager userManager,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository
            )
        {
            _userListExcelExporter = userListExcelExporter;
            _rolePermissionRepository = rolePermissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _userPolicy = userPolicy;
            _passwordValidators = passwordValidators;
            _passwordHasher = passwordHasher;
            _roleManagementConfig = roleManagementConfig;
            _userManager = userManager;

            AppUrlService = NullAppUrlService.Instance;
        }

        public async Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input)
        {
            var query = GetUsersFilteredQuery(input);

            var userCount = await query.CountAsync();

            var users = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            await FillRoleNames(userListDtos);

            return new PagedResultDto<UserListDto>(
                userCount,
                userListDtos
                );
        }

        public async Task<FileDto> GetUsersToExcel(GetUsersToExcelInput input)
        {
            var query = GetUsersFilteredQuery(input);

            var users = await query
                .OrderBy(input.Sorting)
                .ToListAsync();

            var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            await FillRoleNames(userListDtos);

            return _userListExcelExporter.ExportToFile(userListDtos);
        }

        public async Task CreateOrUpdateUser(CreateOrUpdateUserInput input)
        {
            if (input.User.Id.HasValue)
            {
            }
            else
            {
                await CreateUserAsync(input);
            }
        }





        //[AbpAuthorize(AppPermissions.Pages_Administration_Users_Create)]
        protected virtual async Task CreateUserAsync(CreateOrUpdateUserInput input)
        {

            var user = ObjectMapper.Map<User>(input.User); //Passwords is not mapped (see mapping configuration)
            user.TenantId = AbpSession.TenantId;

            //Set password
            if (input.SetRandomPassword)
            {
                var randomPassword = await _userManager.CreateRandomPassword();
                user.Password = _passwordHasher.HashPassword(user, randomPassword);
                input.User.Password = randomPassword;
            }


            user.ShouldChangePasswordOnNextLogin = input.User.ShouldChangePasswordOnNextLogin;


        }

        private async Task FillRoleNames(IReadOnlyCollection<UserListDto> userListDtos)
        {
            /* This method is optimized to fill role names to given list. */
            var userIds = userListDtos.Select(u => u.Id);

            var userRoles = await _userRoleRepository.GetAll()
                .Where(userRole => userIds.Contains(userRole.UserId))
                .Select(userRole => userRole).ToListAsync();

            var distinctRoleIds = userRoles.Select(userRole => userRole.RoleId).Distinct();

            foreach (var user in userListDtos)
            {
                var rolesOfUser = userRoles.Where(userRole => userRole.UserId == user.Id).ToList();
                user.Roles = ObjectMapper.Map<List<UserListRoleDto>>(rolesOfUser);
            }

            var roleNames = new Dictionary<int, string>();


            foreach (var userListDto in userListDtos)
            {
                foreach (var userListRoleDto in userListDto.Roles)
                {
                    if (roleNames.ContainsKey(userListRoleDto.RoleId))
                    {
                        userListRoleDto.RoleName = roleNames[userListRoleDto.RoleId];
                    }
                }

                userListDto.Roles = userListDto.Roles.Where(r => r.RoleName != null).OrderBy(r => r.RoleName).ToList();
            }
        }

        private IQueryable<User> GetUsersFilteredQuery(IGetUsersInput input)
        {
            var query = UserManager.Users
                .WhereIf(input.Role.HasValue, u => u.Roles.Any(r => r.RoleId == input.Role.Value))
                .WhereIf(input.OnlyLockedUsers, u => u.LockoutEndDateUtc.HasValue && u.LockoutEndDateUtc.Value > DateTime.UtcNow)
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );

            if (input.Permissions != null && input.Permissions.Any(p => !p.IsNullOrWhiteSpace()))
            {
                var staticRoleNames = _roleManagementConfig.StaticRoles.Where(
                    r => r.GrantAllPermissionsByDefault &&
                         r.Side == AbpSession.MultiTenancySide
                ).Select(r => r.RoleName).ToList();

                input.Permissions = input.Permissions.Where(p => !string.IsNullOrEmpty(p)).ToList();

                query = from user in query
                        join ur in _userRoleRepository.GetAll() on user.Id equals ur.UserId into urJoined
                        from ur in urJoined.DefaultIfEmpty()
                        join up in _userPermissionRepository.GetAll()
                            .Where(userPermission => input.Permissions.Contains(userPermission.Name)) on user.Id equals up.UserId into upJoined
                        from up in upJoined.DefaultIfEmpty()
                        join rp in _rolePermissionRepository.GetAll()
                            .Where(rolePermission => input.Permissions.Contains(rolePermission.Name)) on
                            new { RoleId = ur == null ? 0 : ur.RoleId } equals new { rp.RoleId } into rpJoined
                        from rp in rpJoined.DefaultIfEmpty()
                        where (up != null && up.IsGranted) ||
                              (up == null && rp != null && rp.IsGranted)
                        select user;
            }

            return query;
        }

        public Task ResetUserSpecificPermissions(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserPermissions(UpdateUserPermissionsInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task UnlockUser(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
