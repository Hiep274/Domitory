﻿using Abp.AspNetZeroCore;
using Abp.AspNetZeroCore.Timing;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.MailKit;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Abp.Zero.Ldap;
using Castle.MicroKernel.Registration;
using MailKit.Security;
using System;
using tmss.Authorization.Delegation;
using tmss.Authorization.Roles;
using tmss.Authorization.Users;
using tmss.Configuration;
using tmss.DashboardCustomization.Definitions;
using tmss.Debugging;
using tmss.DynamicEntityParameters;
using tmss.Localization;
using tmss.MultiTenancy;
using tmss.Net.Emailing;

namespace tmss
{
    [DependsOn(
        typeof(tmssCoreSharedModule),
        typeof(AbpZeroCoreModule),
        typeof(AbpZeroLdapModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetZeroCoreModule),
        typeof(AbpMailKitModule))]
    public class tmssCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //workaround for issue: https://github.com/aspnet/EntityFrameworkCore/issues/9825
            //related github issue: https://github.com/aspnet/EntityFrameworkCore/issues/10407
            AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue9825", true);

            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            tmssLocalizationConfigurer.Configure(Configuration.Localization);

            //Adding setting providers
            Configuration.Settings.Providers.Add<AppSettingProvider>();

            

            //Adding webhook definition providers
            Configuration.Webhooks.TimeoutDuration = TimeSpan.FromMinutes(1);
            Configuration.Webhooks.IsAutomaticSubscriptionDeactivationEnabled = false;

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = tmssConsts.MultiTenancyEnabled;

            //Enable LDAP authentication 
            //Configuration.Modules.ZeroLdap().Enable(typeof(AppLdapAuthenticationSource));

            //Twilio - Enable this line to activate Twilio SMS integration
            //Configuration.ReplaceService<ISmsSender,TwilioSmsSender>();

            //Adding DynamicEntityParameters definition providers
            Configuration.DynamicEntityParameters.Providers.Add<AppDynamicEntityParameterDefinitionProvider>();

            // MailKit configuration
            Configuration.Modules.AbpMailKit().SecureSocketOption = SecureSocketOptions.Auto;
            Configuration.ReplaceService<IMailKitSmtpBuilder, tmssMailKitSmtpBuilder>(DependencyLifeStyle.Transient);

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            if (DebugHelper.IsDebug)
            {
                //Disabling email sending in debug mode
                Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            }

            Configuration.ReplaceService(typeof(IEmailSenderConfiguration), () =>
            {
                Configuration.IocManager.IocContainer.Register(
                    Component.For<IEmailSenderConfiguration, ISmtpEmailSenderConfiguration>()
                             .ImplementedBy<tmssSmtpEmailSenderConfiguration>()
                             .LifestyleTransient()
                );
            });



            IocManager.Register<DashboardConfiguration>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(tmssCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Register<IUserDelegationConfiguration, UserDelegationConfiguration>();

            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}