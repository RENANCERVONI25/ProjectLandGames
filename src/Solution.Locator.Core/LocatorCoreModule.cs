using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Solution.Locator.Authorization.Roles;
using Solution.Locator.Authorization.Users;
using Solution.Locator.Configuration;
using Solution.Locator.Localization;
using Solution.Locator.MultiTenancy;
using Solution.Locator.Timing;

namespace Solution.Locator
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class LocatorCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            LocatorLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = LocatorConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

          
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LocatorCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
