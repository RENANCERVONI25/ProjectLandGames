using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Solution.Locator.Authorization.Roles;
using Solution.Locator.Authorization.Users;
using Solution.Locator.MultiTenancy;
using Solution.Locator.Core.Entitities;
using Solution.Locator.EntityFrameworkCore.Config;
using Abp.Domain.Repositories;

namespace Solution.Locator.EntityFrameworkCore
{
   
    //typeof(SimpleTaskSystemEfRepositoryBase<,>)
    public class LocatorDbContext : AbpZeroDbContext<Tenant, Role, User, LocatorDbContext>
    {
        /* Define a DbSet for each entity of the application */
     
        public LocatorDbContext(DbContextOptions<LocatorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }

        public virtual DbSet<Friend> Friend { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameConfig());

            modelBuilder.ApplyConfiguration(new FriendConfig());
        }
    }
}
