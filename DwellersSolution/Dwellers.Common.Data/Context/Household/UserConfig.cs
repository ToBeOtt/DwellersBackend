using Dwellers.Common.Data.Models.Household;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Context.Household
{
    public class UserConfig : IEntityTypeConfiguration<DwellerUserEntity>
    {
        public void Configure(EntityTypeBuilder<DwellerUserEntity> builder)
        {
            builder.Property(x => x.Alias)
                     .IsRequired()
                     .HasMaxLength(250);
        }
    }
}
