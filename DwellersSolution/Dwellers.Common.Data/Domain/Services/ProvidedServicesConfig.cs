using Dwellers.Common.Data.Models.DwellerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Services
{
    internal class ProvidedServicesConfig : IEntityTypeConfiguration<ProvidedServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvidedServiceEntity> builder)
        {
            builder.HasOne(ds => ds.Service)
                .WithMany(ps => ps.ProvidedServices)
                .HasForeignKey(ds => ds.ServiceId);

            builder.HasOne(h => h.House)
                .WithMany(ps => ps.ProvidedServices)
                .HasForeignKey(h => h.HouseId);
        }
    }
}
