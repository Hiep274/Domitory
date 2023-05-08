using Abp.Application.Editions;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityParameters;
using Abp.EntityHistory;
using Abp.Localization;
using AutoMapper;
using tmss.Auditing.Dto;
using tmss.Authorization.Accounts.Dto;
using tmss.Authorization.Permissions.Dto;
using tmss.Authorization.Users;
using tmss.Authorization.Users.Dto;
using tmss.Authorization.Users.Importing.Dto;
using tmss.Chat;
using tmss.Chat.Dto;
using tmss.Dormitory;
using tmss.Dormitory.IStudent.Dto;
using tmss.Editions;
using tmss.Localization.Dto;
using tmss.MultiTenancy;
using tmss.MultiTenancy.Dto;
using tmss.MultiTenancy.Payments;
using tmss.Sessions.Dto;


namespace tmss
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserRole, UserListRoleDto>();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();
            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<Tenant, TenantListLoginDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<ImportUserDto, User>();
            configuration.CreateMap<AuditLog, AuditLogListDto>();
          
            configuration.CreateMap<Student, CreateOrEditStudentDto>().ReverseMap();

        }
    }
}