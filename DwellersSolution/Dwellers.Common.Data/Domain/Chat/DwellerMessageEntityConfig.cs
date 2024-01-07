using Dwellers.Common.Data.Models.DwellerChat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dwellers.Common.Data.Domain.Chat
{
    internal class DwellerMessageEntityConfig : IEntityTypeConfiguration<DwellerMessageEntity>
    {
        public void Configure(EntityTypeBuilder<DwellerMessageEntity> builder)
        {
            builder.ToTable("DwellerMessages");

            builder.HasKey(bi => bi.Id);

            // Define the properties
            builder.Property(bi => bi.DwellerId).IsRequired();
            builder.Property(bi => bi.ConversationId).IsRequired();
        }
    }
}
