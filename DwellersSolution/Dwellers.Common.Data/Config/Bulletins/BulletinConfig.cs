using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Graph.Models;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinScope;

namespace Dwellers.Common.Data.Config.Bulletins
{
    internal class BulletinConfig : IEntityTypeConfiguration<Bulletin>
    {
        public void Configure(EntityTypeBuilder<Bulletin> builder)
        {

            // Configure converters for IDs
            var scopeIdConverter = new ValueConverter<ScopeId, Guid>(
                id => id.Value,
                guid => new ScopeId(guid));

            var bulletinIdConverter = new ValueConverter<BulletinId, Guid>(
                id => id.Value,
                guid => new BulletinId(guid));

            builder.ToTable("Bulletins");

            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property<BulletinId>("Id").HasConversion(bulletinIdConverter);

            builder.Property<string>("_title").HasColumnName("Title");
            builder.Property<string>("_text").HasColumnName("Text");

            builder.Property<bool>("_isArchived").HasColumnName("IsArchived");
            builder.Property<DateTime>("isCreated").HasColumnName("IsCreated");
            builder.Property<DateTime>("_isModified").HasColumnName("IsModified");

            builder.Property<string>("_userId").HasColumnName("UserId");

            builder.OwnsOne<BulletinPriority>("_priority")
                .Property<Priority>("_priority").HasColumnName("Priority");

            builder.OwnsOne<BulletinStatus>("_status", s =>
            {
                s.Property<Dwellers.Bulletins.Domain.Bulletins.Status>("_status").HasColumnName("Status");
            });

            builder.OwnsMany<BulletinTag>("_tags", b =>
            {
                b.WithOwner().HasForeignKey("_bulletinId").HasConstraintName("FK_BulletinTag_BulletinId");
                b.Property<string>("_tag").HasColumnName("Tag");
                b.Property<BulletinId>("_bulletinId").HasColumnName("BulletinId").HasConversion(bulletinIdConverter);
            });

            builder.OwnsOne<BulletinScope>("_scope", scope =>
            {
                scope.ToTable("BulletinScope");
                //scope.Property<ScopeId>("_scopeId").HasColumnName("ScopeId").HasConversion(scopeIdConverter);

                scope.WithOwner().HasForeignKey("BulletinId");
                //scope.Property<BulletinId>("_bulletinId").HasColumnName("BulletinId").HasConversion(bulletinIdConverter);

                scope.Property<Visibility>("Visibility").HasColumnName("Visibility");

                scope.OwnsMany<ScopedHouse>("_listOfHouses", houses =>
                {
                    houses.WithOwner().HasForeignKey("ScopeId");
                    houses.Property<Guid>("_scopedHouseId").HasColumnName("HouseId");
                });
            });

        }
    }
}
