using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Data.Context
{
    public class DwellerDbContext : DbContext
    {
        public DwellerDbContext(DbContextOptions<DwellerDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dweller> Dwellers { get; set; } 

        public DbSet<DwellingInhabitant> DwellingInhabitants { get; set; }
        public DbSet<Dwelling> Dwellings { get; set; } 

        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<MemberInConversation> MemberInConversations { get; set; }

        public DbSet<Bulletin> Bulletins { get; set; }

        public DbSet<DwellerEventEntity> DwellerEvents { get; set; } 

        public DbSet<DwellerItemEntity> DwellerItems { get; set; } 
        public DbSet<BorrowedItemEntity> BorrowedItems { get; set; } 

        public DbSet<DwellerServiceEntity> DwellerServices { get; set; } 
        public DbSet<ProvidedServiceEntity> ProvidedServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
          => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); 
    }
}
