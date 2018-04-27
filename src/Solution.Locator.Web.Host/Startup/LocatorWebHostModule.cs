using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Solution.Locator.Configuration;

namespace Solution.Locator.Web.Host.Startup
{
    [DependsOn(
       typeof(LocatorWebCoreModule))]
    public class LocatorWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LocatorWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LocatorWebHostModule).GetAssembly());
        }
    }
}
