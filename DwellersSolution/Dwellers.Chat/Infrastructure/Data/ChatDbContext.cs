using Dwellers.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Chat.Infrastructure.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
        }

        public DbSet<DwellerMessage> DwellerMessages { get; set; } = null!;
        public DbSet<DwellerConversation> DwellerConversations { get; set; } = null!;
        public DbSet<HouseConversation> HouseConversations { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HouseConversation>()
                .HasKey(hc => hc.Id);

            builder.Entity<HouseConversation>()
                .Property(hc => hc.HouseId);

            builder.Entity<HouseConversation>()
                .Property(hc => hc.DwellerConversationId);

        }
    }
}
