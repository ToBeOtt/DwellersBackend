using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Entities.Chat;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerServices;
using Dwellers.Household.Domain.Entities.Notes;
using Dwellers.Household.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Data;

public class HouseholdDbContext : IdentityDbContext<DwellerUser>
{
    public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options)
        : base(options)
    {
    }

    public DbSet<DwellerUser> Users { get; set; } = null!;

    public DbSet<HouseUser> HouseUsers { get; set; } = null!;
    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<HouseNoteholder> HouseNoteholders { get; set; } = null!;


    public DbSet<Noteholder> Noteholders { get; set; } = null!;
    public DbSet<NoteholderNotes> NoteholderNotes { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;

    public DbSet<DwellerEvent> Events { get; set; } = null!;

    public DbSet<DwellerMessage> DwellerMessages { get; set; } = null!;
    public DbSet<DwellerConversation> DwellerConversations { get; set; } = null!;
    public DbSet<HouseConversation> HouseConversations { get; set; } = null!;

    public DbSet<DwellerItem> DwellerItems { get; set; } = null!;
    public DbSet<BorrowedItem> BorrowedItems { get; set; } = null!;

    public DbSet<DwellerService> DwellerServices { get; set; } = null!;
    public DbSet<ProvidedService> ProvidedServices { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("HouseholdSchema");

        builder.Entity<DwellerUser>()
           .Property(u => u.ProfilePhoto)
           .HasColumnType("varbinary(max)");

        builder.Entity<DwellerItem>()
          .Property(u => u.ItemPhoto)
          .HasColumnType("varbinary(max)");

        builder.Entity<House>()
         .Property(u => u.HousePhoto)
         .HasColumnType("varbinary(max)");

        builder.Entity<HouseUser>()
           .HasOne(hu => hu.House)
           .WithMany(h => h.HouseUsers)
           .HasForeignKey(hu => hu.HouseId);

        builder.Entity<HouseUser>()
            .HasOne(hu => hu.User)
            .WithMany(u => u.HouseUsers)
            .HasForeignKey(hu => hu.UserId);

        builder.Entity<HouseNoteholder>()
          .HasOne(hnh => hnh.House)
          .WithMany(h => h.HouseNoteholders)
          .HasForeignKey(hnh => hnh.HouseId);

        builder.Entity<HouseNoteholder>()
            .HasOne(hnh => hnh.Noteholder)
            .WithMany(u => u.HouseNoteholders)
            .HasForeignKey(hnh => hnh.NoteholderId);

        builder.Entity<NoteholderNotes>()
          .HasOne(nhn => nhn.Noteholder)
          .WithMany(nh => nh.NoteholderNotes)
          .HasForeignKey(nhn => nhn.NoteholderId);

        builder.Entity<NoteholderNotes>()
            .HasOne(nhn => nhn.Note)
            .WithMany(n => n.NoteholderNotes)
            .HasForeignKey(nhn => nhn.NoteId);

        builder.Entity<HouseConversation>()
          .HasOne(h => h.House)
          .WithMany(hc => hc.HouseConversations)
          .HasForeignKey(h => h.HouseId);

        builder.Entity<HouseConversation>()
            .HasOne(dc => dc.DwellerConversation)
            .WithMany(hc => hc.HouseConversations)
            .HasForeignKey(dc => dc.DwellerConversationId);

        builder.Entity<BorrowedItem>()
         .HasOne(di => di.DwellerItem)
         .WithMany(bi => bi.BorrowedItems)
         .HasForeignKey(di => di.DwellerItemId);

        builder.Entity<BorrowedItem>()
            .HasOne(h => h.House)
            .WithMany(bi => bi.BorrowedItems)
            .HasForeignKey(h => h.HouseId);

        builder.Entity<ProvidedService>()
         .HasOne(ds => ds.DwellerService)
         .WithMany(ps => ps.ProvidedServices)
         .HasForeignKey(ds => ds.DwellerServiceId);

        builder.Entity<ProvidedService>()
            .HasOne(h => h.House)
            .WithMany(ps => ps.ProvidedServices)
            .HasForeignKey(h => h.HouseId);

    }
}