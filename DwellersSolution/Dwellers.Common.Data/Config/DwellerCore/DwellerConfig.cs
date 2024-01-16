using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Config.DwellerCore
{
    internal class DwellerConfig : IEntityTypeConfiguration<Dweller>
    {
        public void Configure(EntityTypeBuilder<Dweller> builder)
        {
            builder.ToTable("Dwellers");

            builder.HasKey(x => x.Id).HasName("Id");

            builder.Property<string>("_alias").HasColumnName("Alias");
            builder.Property<string>("_email").HasColumnName("Email");

            builder.Property<byte[]>("_profilePhoto").HasColumnName("ProfilePhoto");

            builder.Property<bool>("_isArchived").HasColumnName("IsArchived");
            builder.Property<DateTime>("isCreated").HasColumnName("IsCreated");
            builder.Property<DateTime>("_isModified").HasColumnName("IsModified");

        }
    }
}
