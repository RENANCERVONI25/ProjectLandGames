using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Solution.Locator.Configuration;
using Solution.Locator.Web;

namespace Solution.Locator.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LocatorDbContextFactory : IDesignTimeDbContextFactory<LocatorDbContext>
    {
        public LocatorDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LocatorDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LocatorDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LocatorConsts.ConnectionStringName));

            return new LocatorDbContext(builder.Options);
        }
    }
}
