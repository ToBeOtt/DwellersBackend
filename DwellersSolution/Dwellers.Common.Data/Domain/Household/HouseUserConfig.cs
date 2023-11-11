using Dwellers.Common.Data.Models.Household;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Household
{
    internal class HouseUserConfig : IEntityTypeConfiguration<HouseUserEntity>
    {
        public void Configure(EntityTypeBuilder<HouseUserEntity> builder)
        {
            builder.HasOne(hu => hu.House)
               .WithMany(h => h.HouseUsers)
               .HasForeignKey(hu => hu.HouseId);

            builder.HasOne(hu => hu.User)
                .WithMany(u => u.HouseUsers)
                .HasForeignKey(hu => hu.UserId);
        }
    }
}
