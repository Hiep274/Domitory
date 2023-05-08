using Abp;
using Abp.Dependency;
using Abp.Organizations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tmss.Authorization.Roles;
using tmss.Authorization.Users;
using tmss.Configuration;

namespace tmss.MultiTenancy.Demo
{
    /// <summary>
    /// Used to build demo data for new tenants.
    /// Creates sample organization units, users... etc.
    /// It works only if in DEMO mode ("App.DemoMode" should be "true" in web.config). Otherwise, does nothing.
    /// </summary>
    public class TenantDemoDataBuilder : tmssServiceBase, ITransientDependency
    {
        public bool IsInDemoMode
        {
            get
            {
                return string.Equals(_appConfiguration["App:DemoMode"], "true", StringComparison.OrdinalIgnoreCase);
            }
        }

        private readonly UserManager _userManager;
        private readonly RandomUserGenerator _randomUserGenerator;
        private readonly IAppFolders _appFolders;
        private readonly IConfigurationRoot _appConfiguration;

        public TenantDemoDataBuilder(
            OrganizationUnitManager organizationUnitManager,
            UserManager userManager,
            RandomUserGenerator randomUserGenerator,
            IAppFolders appFolders,
            IAppConfigurationAccessor configurationAccessor)
        {
            _userManager = userManager;
            _randomUserGenerator = randomUserGenerator;
            _appFolders = appFolders;

            _appConfiguration = configurationAccessor.Configuration;
        }

        public async Task BuildForAsync(Tenant tenant)
        {
            if (!IsInDemoMode)
            {
                return;
            }

            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                await BuildForInternalAsync(tenant);
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            await EnableIsNewRegisteredUserActiveByDefaultAsync(tenant);
        }

        private async Task BuildForInternalAsync(Tenant tenant)
        {
            //Create Organization Units

            var organizationUnits = new List<OrganizationUnit>();

          

            //Create users

            var users = _randomUserGenerator.GetRandomUsers(RandomHelper.GetRandom(12, 26), tenant.Id);
            foreach (var user in users)
            {
                //Create the user
                await _userManager.CreateAsync(user);
                await CurrentUnitOfWork.SaveChangesAsync();

                //Add to roles
                await _userManager.AddToRoleAsync(user, StaticRoleNames.Tenants.User);

                //Add to OUs
                var randomOus = RandomHelper.GenerateRandomizedList(organizationUnits).Take(RandomHelper.GetRandom(0, 3));
                foreach (var ou in randomOus)
                {
                    await _userManager.AddToOrganizationUnitAsync(user, ou);
                }


            }

        }

        private async Task EnableIsNewRegisteredUserActiveByDefaultAsync(Tenant tenant)
        {
            await SettingManager.ChangeSettingForTenantAsync(tenant.Id, AppSettings.UserManagement.IsNewRegisteredUserActiveByDefault, "true");
        }

       



        private byte[] GetRandomProfilePictureBytes()
        {
            var fileName = string.Format("sample-profile-{0}.jpg", (RandomHelper.GetRandom(1, 11)).ToString("00"));
            var fullPath = Path.Combine(_appFolders.SampleProfileImagesFolder, fileName);

            if (!File.Exists(fullPath))
            {
                throw new Exception("Could not find sample profile picture on " + fullPath);
            }

            return File.ReadAllBytes(fullPath);
        }
    }
}
