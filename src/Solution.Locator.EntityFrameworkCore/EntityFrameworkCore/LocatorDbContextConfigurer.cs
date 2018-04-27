using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Solution.Locator.EntityFrameworkCore
{
    public static class LocatorDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LocatorDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LocatorDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
