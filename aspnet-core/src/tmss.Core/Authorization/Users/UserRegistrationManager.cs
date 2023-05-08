using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.IdentityFramework;
using Abp.Linq;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmss.Authorization.Roles;
using tmss.Configuration;
using tmss.MultiTenancy;

namespace tmss.Authorization.Users
{
    public class UserRegistrationManager : tmssDomainServiceBase
    {
        public IAbpSession AbpSession { get; set; }
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IUserPolicy _userPolicy;


        public UserRegistrationManager(
            TenantManager tenantManager,
            UserManager userManager,
            RoleManager roleManager,
            IUserPolicy userPolicy)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userPolicy = userPolicy;

            AbpSession = NullAbpSession.Instance;
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        public async Task<User> RegisterAsync(string name, string surname, string emailAddress, string userName, string plainPassword, bool isEmailConfirmed, string emailActivationLink)
        {
            CheckForTenant();
            CheckSelfRegistrationIsEnabled();

            var tenant = await GetActiveTenantAsync();
            var isNewRegisteredUserActiveByDefault = await SettingManager.GetSettingValueAsync<bool>(AppSettings.UserManagement.IsNewRegisteredUserActiveByDefault);


            var user = new User
            {
                TenantId = tenant.Id,
                Name = name,
                Surname = surname,
                EmailAddress = emailAddress,
                IsActive = isNewRegisteredUserActiveByDefault,
                UserName = userName,
                IsEmailConfirmed = isEmailConfirmed,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            var defaultRoles = await AsyncQueryableExecuter.ToListAsync(_roleManager.Roles.Where(r => r.IsDefault));
            foreach (var defaultRole in defaultRoles)
            {
                user.Roles.Add(new UserRole(tenant.Id, user.Id, defaultRole.Id));
            }

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, plainPassword));
            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        private void CheckForTenant()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("Can not register host users!");
            }
        }

        private void CheckSelfRegistrationIsEnabled()
        {
            if (!SettingManager.GetSettingValue<bool>(AppSettings.UserManagement.AllowSelfRegistration))
            {
                throw new UserFriendlyException(L("SelfUserRegistrationIsDisabledMessage_Detail"));
            }
        }

        private bool UseCaptchaOnRegistration()
        {
            return SettingManager.GetSettingValue<bool>(AppSettings.UserManagement.UseCaptchaOnRegistration);
        }

        private async Task<Tenant> GetActiveTenantAsync()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return await GetActiveTenantAsync(AbpSession.TenantId.Value);
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            var tenant = await _tenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
