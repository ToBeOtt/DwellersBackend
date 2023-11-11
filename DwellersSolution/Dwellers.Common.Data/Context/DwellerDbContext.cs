using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Data.Models.Notes;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Data.Context
{
    public class DwellerDbContext : DbContext
    {
        public DwellerDbContext(DbContextOptions<DwellerDbContext> options)
            : base(options)
        {
        }
        public DbSet<DwellerUserEntity> Users { get; set; } 

        public DbSet<HouseUserEntity> HouseUsers { get; set; }
        public DbSet<HouseEntity> Houses { get; set; } 

        public DbSet<DwellerMessageEntity> DwellerMessages { get; set; }
        public DbSet<DwellerConversationEntity> DwellerConversations { get; set; }
        public DbSet<HouseConversationEntity> HouseConversations { get; set; }


        public DbSet<Bulletin> Bulletins { get; set; }


        public DbSet<NoteEntity> Notes { get; set; } 

        public DbSet<DwellerEventEntity> DwellerEvents { get; set; } 

        public DbSet<DwellerItemEntity> DwellerItems { get; set; } 
        public DbSet<BorrowedItemEntity> BorrowedItems { get; set; } 

        public DbSet<DwellerServiceEntity> DwellerServices { get; set; } 
        public DbSet<ProvidedServiceEntity> ProvidedServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
          => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); 
    }
}
