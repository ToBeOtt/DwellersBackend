using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Data.Context.Household
{
    public class DwellerHouseConfig : IEntityTypeConfiguration<HouseEntity>
    {
        public void Configure(EntityTypeBuilder<HouseEntity> builder)
        {
            builder.Property(x => x.Name)
                     .IsRequired()
                     .HasMaxLength(250);
        }
    }
}
