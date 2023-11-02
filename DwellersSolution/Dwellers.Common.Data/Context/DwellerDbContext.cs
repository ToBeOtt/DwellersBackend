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
        public DbSet<DwellerUserEntity> Users { get; set; } = null!;

        public DbSet<HouseUserEntity> HouseUsers { get; set; } = null!;
        public DbSet<HouseEntity> Houses { get; set; } = null!;
        public DbSet<HouseNoteholderEntity> HouseNoteholders { get; set; } = null!;

        public DbSet<DwellerMessageEntity> DwellerMessages { get; set; } = null!;
        public DbSet<DwellerConversationEntity> DwellerConversations { get; set; } = null!;
        public DbSet<HouseConversationEntity> HouseConversations { get; set; } = null!;

        public DbSet<NoteholderEntity> Noteholders { get; set; } = null!;
        public DbSet<NoteholderNotesEntity> NoteholderNotes { get; set; } = null!;
        public DbSet<NoteEntity> Notes { get; set; } = null!;

        public DbSet<DwellerEventEntity> DwellerEvents { get; set; } = null!;

        public DbSet<DwellerItemEntity> DwellerItems { get; set; } = null!;
        public DbSet<BorrowedItemEntity> BorrowedItems { get; set; } = null!;

        public DbSet<DwellerServiceEntity> DwellerServices { get; set; } = null!;
        public DbSet<ProvidedServiceEntity> ProvidedServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<HouseUserEntity>()
               .HasOne(hu => hu.House)
               .WithMany(h => h.HouseUsers)
               .HasForeignKey(hu => hu.HouseId);

            builder.Entity<HouseUserEntity>()
                .HasOne(hu => hu.User)
                .WithMany(u => u.HouseUsers)
                .HasForeignKey(hu => hu.UserId);

            builder.Entity<HouseNoteholderEntity>()
              .HasOne(hnh => hnh.House)
              .WithMany(h => h.HouseNoteholders)
              .HasForeignKey(hnh => hnh.HouseId);

            builder.Entity<HouseNoteholderEntity>()
                .HasOne(hnh => hnh.Noteholder)
                .WithMany(u => u.HouseNoteholders)
                .HasForeignKey(hnh => hnh.NoteholderId);

            builder.Entity<NoteholderNotesEntity>()
              .HasOne(nhn => nhn.Noteholder)
              .WithMany(nh => nh.NoteholderNotes)
              .HasForeignKey(nhn => nhn.NoteholderId);

            builder.Entity<NoteholderNotesEntity>()
                .HasOne(nhn => nhn.Note)
                .WithMany(n => n.NoteholderNotes)
                .HasForeignKey(nhn => nhn.NoteId);

            builder.Entity<BorrowedItemEntity>()
             .HasOne(di => di.Item)
             .WithMany(bi => bi.BorrowedItems)
             .HasForeignKey(di => di.ItemId);

            builder.Entity<BorrowedItemEntity>()
                .HasOne(h => h.House)
                .WithMany(bi => bi.BorrowedItems)
                .HasForeignKey(h => h.HouseId);

            builder.Entity<ProvidedServiceEntity>()
             .HasOne(ds => ds.Service)
             .WithMany(ps => ps.ProvidedServices)
             .HasForeignKey(ds => ds.ServiceId);

            builder.Entity<ProvidedServiceEntity>()
                .HasOne(h => h.House)
                .WithMany(ps => ps.ProvidedServices)
                .HasForeignKey(h => h.HouseId);
        }
    }
}
