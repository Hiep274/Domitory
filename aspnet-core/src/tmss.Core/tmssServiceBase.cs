using Abp;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.Threading;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using tmss.Authorization.Users;
using tmss.MultiTenancy;
using tmss.MultiTenancy.Dto;
namespace tmss
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="tmssDomainServiceBase"/>.
    /// For application services inherit tmssAppServiceBase.
    /// </summary>
    public abstract class tmssServiceBase : AbpServiceBase
    {
        protected tmssServiceBase()
        {
            LocalizationSourceName = tmssConsts.LocalizationSourceName;
        }
        //public TenantManager TenantManager { get; set; }

        //public UserManager UserManager { get; set; }
        //
        // Summary:
        //     Gets current session information.
        public IAbpSession AbpSession { get; set; }
        //protected virtual async Task<User> GetCurrentUserAsync()
        //{
        //    var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
        //    if (user == null)
        //    {
        //        throw new Exception("There is no current user!");
        //    }

        //    return user;
        //}
        //protected virtual TenantListLoginDto GetTenantsCurrentLogin()
        //{
        //    var tenants = TenantManager.Tenants.FirstOrDefault(t => t.Id == AbpSession.TenantId);

        //    return ObjectMapper.Map<TenantListLoginDto>(tenants);
        //}
        //protected virtual User GetCurrentUser()
        //{
        //    return AsyncHelper.RunSync(GetCurrentUserAsync);
        //}

        //protected virtual Task<Tenant> GetCurrentTenantAsync()
        //{
        //    using (CurrentUnitOfWork.SetTenantId(null))
        //    {
        //        return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        //    }
        //}

        //protected virtual Tenant GetCurrentTenant()
        //{
        //    using (CurrentUnitOfWork.SetTenantId(null))
        //    {
        //        return TenantManager.GetById(AbpSession.GetTenantId());
        //    }
        //}

        //protected virtual void CheckErrors(IdentityResult identityResult)
        //{
        //    identityResult.CheckErrors(LocalizationManager);
        //}

    }
}