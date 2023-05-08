using Abp.Application.Services;
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
    /// Derive your application services from this class.
    /// </summary>
    public abstract class tmssAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }
        protected tmssAppServiceBase()
        {
            LocalizationSourceName = tmssConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }
        protected virtual TenantListLoginDto GetTenantsCurrentLogin()
        {
            var tenants = TenantManager.Tenants.FirstOrDefault(t => t.Id == AbpSession.TenantId);

            return ObjectMapper.Map<TenantListLoginDto>(tenants);
        }
        protected virtual User GetCurrentUser()
        {
            return AsyncHelper.RunSync(GetCurrentUserAsync);
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
            }
        }

        protected virtual Tenant GetCurrentTenant()
        {
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                return TenantManager.GetById(AbpSession.GetTenantId());
            }
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}