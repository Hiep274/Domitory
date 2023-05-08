using Abp.Authorization.Users;
using System.Threading.Tasks;
using tmss.Authorization.Users;

namespace tmss.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
