using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Solution.Locator.Configuration;

namespace Solution.Locator.Web.Startup
{
    [DependsOn(typeof(LocatorWebCoreModule))]
    public class LocatorWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LocatorWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<LocatorNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LocatorWebMvcModule).GetAssembly());
        }
    }
}
