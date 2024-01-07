using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.Graph.Models;

namespace Dwellers.Common.Data.Domain.Chat
{
    internal class DwellingConversationEntityConfig : IEntityTypeConfiguration<DwellingConversationEntity>
    {
        public void Configure(EntityTypeBuilder<DwellingConversationEntity> builder)
        {
            builder.ToTable("DwellingConversations");

            builder.HasKey(bi => bi.Id);

            // Define the properties
            builder.Property(bi => bi.DwellingId).IsRequired();
            builder.Property(bi => bi.ConversationId).IsRequired();

            builder.Property(bi => bi.Archived);
            builder.Property(bi => bi.IsCreated);
            builder.Property(bi => bi.IsModified);

        
            builder.HasOne<Dwelling>() 
                .WithMany() 
                .HasForeignKey(bi => bi.DwellingId);

            builder.HasOne<DwellerConversationEntity>() 
                .WithMany() 
                .HasForeignKey(bi => bi.ConversationId);
        }
    }
}
