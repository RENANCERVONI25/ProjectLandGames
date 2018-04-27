using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero;
using Castle.MicroKernel.Registration;
using Solution.Locator.Authorization;
using Solution.Locator.Core;
using Solution.Locator.EntityFrameworkCore.Repositories;

namespace Solution.Locator
{
    [DependsOn(
        typeof(LocatorCoreModule), 
        typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpZeroCommonModule))]
    public class LocatorApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LocatorAuthorizationProvider>();

       
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LocatorApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
