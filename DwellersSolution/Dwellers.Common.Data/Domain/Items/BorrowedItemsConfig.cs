using Dwellers.Common.Data.Models.DwellerItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Items
{
    internal class BorrowedItemsConfig : IEntityTypeConfiguration<BorrowedItemEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowedItemEntity> builder)
        {
            builder.HasOne(di => di.Item)
               .WithMany(bi => bi.BorrowedItems)
               .HasForeignKey(di => di.ItemId);

            builder.HasOne(h => h.House)
                   .WithMany(bi => bi.BorrowedItems)
                   .HasForeignKey(h => h.HouseId);
        }
    }
}
