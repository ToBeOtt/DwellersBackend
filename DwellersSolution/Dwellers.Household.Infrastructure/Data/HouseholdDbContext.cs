using Dwellers.Household.Application.Interfaces;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Joins;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Data;

public class HouseholdDbContext : IdentityDbContext<User>, IDbContext
{
    public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<HouseUser> HouseUsers { get; set; } = null!;
    public DbSet<House> Houses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("HouseholdSchema");

        builder.Entity<HouseUser>()
       .HasOne(hu => hu.House)
       .WithMany(h => h.HouseUsers)
       .HasForeignKey(hu => hu.HouseId);

        builder.Entity<HouseUser>()
            .HasOne(hu => hu.User)
            .WithMany(u => u.HouseUsers)
            .HasForeignKey(hu => hu.UserId);
    }
}