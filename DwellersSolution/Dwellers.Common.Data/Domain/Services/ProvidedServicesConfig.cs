using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Services
{
    internal class ProvidedServicesConfig : IEntityTypeConfiguration<ProvidedServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvidedServiceEntity> builder)
        {
            builder.ToTable("BorrowedItems");

            builder.HasKey(bi => bi.Id);

            // Define the properties
            builder.Property(bi => bi.DwellingId).IsRequired();
            builder.Property(bi => bi.ServiceId).IsRequired();
            builder.Property(bi => bi.IsProvider);
            builder.Property(bi => bi.Note);
            builder.Property(bi => bi.ServiceReturned);
            builder.Property(bi => bi.Archived);
            builder.Property(bi => bi.IsCreated);
            builder.Property(bi => bi.IsModified);

            // Configure relationships using shadow properties
            builder.HasOne<Dwelling>().WithMany()
                .HasForeignKey(bi => bi.DwellingId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<DwellerServiceEntity>().WithMany()
                .HasForeignKey(bi => bi.ServiceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
