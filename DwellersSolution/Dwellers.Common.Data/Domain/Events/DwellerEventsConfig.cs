using Dwellers.Common.Data.Models.DwellerEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Events
{
    public class DwellerEventsConfig : IEntityTypeConfiguration<DwellerEventEntity>
    {
        public void Configure(EntityTypeBuilder<DwellerEventEntity> builder)
        {
        }
    }
}
