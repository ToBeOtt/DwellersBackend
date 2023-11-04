using Dwellers.Common.Data.Models.Household;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dwellers.Common.Data.Models.DwellerEvents;

namespace Dwellers.Common.Data.Context.Events
{
    public class DwellerEventsConfig : IEntityTypeConfiguration<DwellerEventEntity>
    {
        public void Configure(EntityTypeBuilder<DwellerEventEntity> builder)
        {
            builder.Property(x => x.Archived != true);

            builder.Property(x => x.User)
                .IsRequired();

        }
    }
}
