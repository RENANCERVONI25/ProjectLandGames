using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Solution.Locator.EntityFrameworkCore.Seed;

namespace Solution.Locator.EntityFrameworkCore
{
    [DependsOn(
        typeof(LocatorCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class LocatorEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<LocatorDbContext>(options =>
                    {
                    if (options.ExistingConnection != null)
                    {
                        LocatorDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        LocatorDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LocatorEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
