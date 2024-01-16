using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinScope;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.Common.Data.Config.DwellerCore
{
    internal class DwellingInhabitantConfig : IEntityTypeConfiguration<DwellingInhabitant>
    {
        public void Configure(EntityTypeBuilder<DwellingInhabitant> builder)
        {
            // Configure converters for IDs
            var idConverter = new ValueConverter<DwellingId, Guid>(
                id => id.Value,
                guid => new DwellingId(guid));

            var dwellingIdConverter = new ValueConverter<DwellingId, Guid>(
                id => id.Value,
                guid => new DwellingId(guid));

            builder.ToTable("DwellingInhabitants");

            // Configuring the primary key
            builder.HasKey("_dwellingInhabitantId");

            // Configuring properties
            builder.Property<Guid>("_dwellingInhabitantId").HasColumnName("DwellingInhabitantId").IsRequired();
            builder.Property<string>("_dwellerId").HasColumnName("DwellerId").IsRequired();
            builder.Property<DwellingId>("_dwellingId").HasConversion(dwellingIdConverter);

            builder.HasOne<Dweller>().WithMany().HasForeignKey("_dwellerId");
            builder.HasOne<Dwelling>().WithMany().HasForeignKey("_dwellingId");
        }
    }
}
