using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Locator.Core.Entitities;

namespace Solution.Locator.EntityFrameworkCore.Config
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public FriendConfig()
        {

        }

        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name);

            builder.Property(c => c.NickName);

            builder.Property(c => c.DateCreated);

            builder.ToTable("AbpFriend");
        }
    }
}
