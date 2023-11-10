using Dwellers.Common.Data.Models.Household;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Bulletins.Domain.Bulletins;

namespace Dwellers.Common.Data.Domain.Events
{
    public class DwellerEventsConfig : IEntityTypeConfiguration<DwellerEventEntity>
    {
        public void Configure(EntityTypeBuilder<DwellerEventEntity> builder)
        {
        }
    }
}
