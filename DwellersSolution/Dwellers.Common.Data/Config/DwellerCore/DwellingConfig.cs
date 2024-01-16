using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.Common.Data.Config.DwellerCore
{
    internal class DwellingConfig : IEntityTypeConfiguration<Dwelling>
    {
        public void Configure(EntityTypeBuilder<Dwelling> builder)
        {
            // Configure converters for IDs
            var idConverter = new ValueConverter<DwellingId, Guid>(
                id => id.Value,
                guid => new DwellingId(guid));

            var dwellingIdConverter = new ValueConverter<DwellingId, Guid>(
                id => id.Value,
                guid => new DwellingId(guid));

            builder.ToTable("Dwellings");

            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property<DwellingId>("Id").HasConversion(dwellingIdConverter);

            builder.Property<Guid>("_invitationCode").HasColumnName("InvitationCode");
            builder.Property<string>("_name").HasColumnName("Name");
            builder.Property<string>("_description").HasColumnName("Description");

            builder.Property<byte[]>("_dwellingProfilePhoto").HasColumnName("DwellingProfilePhoto");

            builder.Property<bool>("_isArchived").HasColumnName("IsArchived");
            builder.Property<DateTime>("isCreated").HasColumnName("IsCreated");
            builder.Property<DateTime>("_isModified").HasColumnName("IsModified");

            builder.OwnsMany<DwellingGallery>("_dwellingGallery", b =>
            {
                b.WithOwner().HasForeignKey("_dwellingId").HasConstraintName("FK_DwellingGallery_DwellingId");
                b.Property<byte[]>("_dwellingImage").HasColumnName("DwellingImage");
                b.Property<DwellingId>("_dwellingId").HasColumnName("DwellingId").HasConversion(dwellingIdConverter);
            });
        }
    }
}
