using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Locator.Core.Entitities;

namespace Solution.Locator.EntityFrameworkCore.Config
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public GameConfig()
        {
         
        }

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name);

            builder.Property(c => c.DateCreated);

            builder.HasOne(c => c.Friend)
           .WithMany(d => d.Games)
           .HasForeignKey(c => c.IdFriend).HasConstraintName("FK_AbpGame_AbpFriend_IdFriend");

            builder.ToTable("AbpGame");
        }
    }
}
