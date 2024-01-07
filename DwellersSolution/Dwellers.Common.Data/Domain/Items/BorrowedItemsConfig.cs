using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Items
{
    internal class BorrowedItemsConfig : IEntityTypeConfiguration<BorrowedItemEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowedItemEntity> builder)
        {
            builder.ToTable("BorrowedItems");

            builder.HasKey(bi => bi.Id);

            // Define the properties
            builder.Property(bi => bi.DwellingId).IsRequired();
            builder.Property(bi => bi.ItemId).IsRequired();
            builder.Property(bi => bi.IsOwner);
            builder.Property(bi => bi.Note);
            builder.Property(bi => bi.Returned);
            builder.Property(bi => bi.Archived);
            builder.Property(bi => bi.IsCreated);
            builder.Property(bi => bi.IsModified);

            // Configure relationships using shadow properties
            builder.HasOne<Dwelling>().WithMany()
                .HasForeignKey(bi => bi.DwellingId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne<DwellerItemEntity>().WithMany()
                .HasForeignKey(bi => bi.ItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
