using Abp.AspNetZeroCore;
using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.AspNetZeroCore.Web.Authentication.External.Facebook;
using Abp.AspNetZeroCore.Web.Authentication.External.Google;
using Abp.AspNetZeroCore.Web.Authentication.External.Microsoft;
using Abp.AspNetZeroCore.Web.Authentication.External.OpenIdConnect;
using Abp.AspNetZeroCore.Web.Authentication.External.WsFederation;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using tmss.Auditing;
using tmss.Configuration;
using tmss.EntityFrameworkCore;
using tmss.MultiTenancy;
using tmss.Web.Common;

namespace tmss.Web.Startup
{
    [DependsOn(
      typeof(tmssWebCoreModule)
  )]
    public class tmssWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public tmssWebHostModule(
            IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:ServerRootAddress"] ?? "https://ssa-api.toyotavn.com.vn/";
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];
            Configuration.BackgroundJobs.IsJobExecutionEnabled = WebConsts.EnableJob;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(tmssWebHostModule).GetAssembly());
            // Devexpress
            IocManager.Register(typeof(DXWebDocumentViewerController), DependencyLifeStyle.Transient);
        }

        public override void PostInitialize()
        {
            using (var scope = IocManager.CreateScope())
            {
                if (!scope.Resolve<DatabaseCheckHelper>().Exist(_appConfiguration["ConnectionStrings:Default"]))
                {
                    return;
                    //  IocManager.RegisterAssemblyByConvention(typeof(tmssWebHostModule).GetAssembly());
                    // Devexpress
                    // IocManager.Register(typeof(DXWebDocumentViewerController), DependencyLifeStyle.Transient);
                }
            }

            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            if (IocManager.Resolve<IMultiTenancyConfig>().IsEnabled)
            {
                workManager.Add(IocManager.Resolve<SubscriptionExpirationCheckWorker>());
                workManager.Add(IocManager.Resolve<SubscriptionExpireEmailNotifierWorker>());
            }

            if (Configuration.Auditing.IsEnabled && ExpiredAuditLogDeleterWorker.IsEnabled)
            {
                workManager.Add(IocManager.Resolve<ExpiredAuditLogDeleterWorker>());
            }

            Configuration.BackgroundJobs.IsJobExecutionEnabled = WebConsts.EnableJob;

            ConfigureExternalAuthProviders();
        }

        private void ConfigureExternalAuthProviders()
        {
            var externalAuthConfiguration = IocManager.Resolve<ExternalAuthConfiguration>();

            if (bool.Parse(_appConfiguration["Authentication:OpenId:IsEnabled"]))
            {
                var jsonClaimMappings = new List<JsonClaimMap>();
                _appConfiguration.GetSection("Authentication:OpenId:ClaimsMapping").Bind(jsonClaimMappings);

                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        OpenIdConnectAuthProviderApi.Name,
                        _appConfiguration["Authentication:OpenId:ClientId"],
                        _appConfiguration["Authentication:OpenId:ClientSecret"],
                        typeof(OpenIdConnectAuthProviderApi),
                        new Dictionary<string, string>
                        {
                            {"Authority", _appConfiguration["Authentication:OpenId:Authority"]},
                            {"LoginUrl",_appConfiguration["Authentication:OpenId:LoginUrl"]},
                            {"ValidateIssuer",_appConfiguration["Authentication:OpenId:ValidateIssuer"]}
                        },
                        jsonClaimMappings
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:WsFederation:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        WsFederationAuthProviderApi.Name,
                        _appConfiguration["Authentication:WsFederation:ClientId"],
                        "",
                        typeof(WsFederationAuthProviderApi),
                        new Dictionary<string, string>
                        {
                            {"Tenant", _appConfiguration["Authentication:WsFederation:Tenant"]},
                            {"MetaDataAddress", _appConfiguration["Authentication:WsFederation:MetaDataAddress"]},
                            {"Authority", _appConfiguration["Authentication:WsFederation:Authority"]}
                        })
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:Facebook:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        FacebookAuthProviderApi.Name,
                        _appConfiguration["Authentication:Facebook:AppId"],
                        _appConfiguration["Authentication:Facebook:AppSecret"],
                        typeof(FacebookAuthProviderApi)
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:Google:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        GoogleAuthProviderApi.Name,
                        _appConfiguration["Authentication:Google:ClientId"],
                        _appConfiguration["Authentication:Google:ClientSecret"],
                        typeof(GoogleAuthProviderApi),
                        new Dictionary<string, string>
                        {
                            {"UserInfoEndpoint", _appConfiguration["Authentication:Google:UserInfoEndpoint"]}
                        }
                    )
                );
            }

            //not implemented yet. Will be implemented with https://github.com/aspnetzero/aspnet-zero-angular/issues/5
            if (bool.Parse(_appConfiguration["Authentication:Microsoft:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        MicrosoftAuthProviderApi.Name,
                        _appConfiguration["Authentication:Microsoft:ConsumerKey"],
                        _appConfiguration["Authentication:Microsoft:ConsumerSecret"],
                        typeof(MicrosoftAuthProviderApi)
                    )
                );
            }
        }
    }
}
