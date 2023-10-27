﻿// <auto-generated />
using System;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dwellers.Household.Migrations
{
    [DbContext(typeof(HouseholdDbContext))]
    [Migration("20231012074506_InitReboot")]
    partial class InitReboot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("HouseholdSchema")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Chat.DwellerMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("DwellerMessages", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Chat.HouseConversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DwellerConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DwellerConversationId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseConversations", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerEvents.DwellerEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EventModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventScope")
                        .HasColumnType("int");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("Events", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerHouse.House", b =>
                {
                    b.Property<Guid>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HousePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("HouseholdCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HouseId");

                    b.ToTable("Houses", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerHouse.HouseUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("HouseUsers", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerItems.BorrowedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DwellerItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DwellerItemId");

                    b.HasIndex("HouseId");

                    b.ToTable("BorrowedItems", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerItems.DwellerItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ItemPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ItemScope")
                        .HasColumnType("int");

                    b.Property<bool>("ItemStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DwellerItems", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerServices.DwellerService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceScope")
                        .HasColumnType("int");

                    b.Property<bool>("ServiceStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DwellerServices", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerServices.ProvidedService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DwellerServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsProvider")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ServiceReturned")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DwellerServiceId");

                    b.HasIndex("HouseId");

                    b.ToTable("ProvidedServices", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.HouseNoteholder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteholderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("NoteholderId");

                    b.ToTable("HouseNoteholders", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NoteCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NoteModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NotePriority")
                        .HasColumnType("int");

                    b.Property<int?>("NoteScope")
                        .HasColumnType("int");

                    b.Property<int?>("NoteStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NoteId");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.Noteholder", b =>
                {
                    b.Property<Guid>("NoteholderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteholderScope")
                        .HasColumnType("int");

                    b.HasKey("NoteholderId");

                    b.ToTable("Noteholders", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.NoteholderNotes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteholderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("NoteholderId");

                    b.ToTable("NoteholderNotes", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.ValueObjects.DwellerConversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DwellerConversations", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "HouseholdSchema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "HouseholdSchema");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Chat.DwellerMessage", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.ValueObjects.DwellerConversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", "User")
                        .WithMany("DwellerMessages")
                        .HasForeignKey("UserId");

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Chat.HouseConversation", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.ValueObjects.DwellerConversation", "DwellerConversation")
                        .WithMany("HouseConversations")
                        .HasForeignKey("DwellerConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("HouseConversations")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DwellerConversation");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerEvents.DwellerEvent", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerHouse.HouseUser", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("HouseUsers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", "User")
                        .WithMany("HouseUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerItems.BorrowedItem", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerItems.DwellerItem", "DwellerItem")
                        .WithMany("BorrowedItems")
                        .HasForeignKey("DwellerItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("BorrowedItems")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DwellerItem");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerServices.ProvidedService", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerServices.DwellerService", "DwellerService")
                        .WithMany("ProvidedServices")
                        .HasForeignKey("DwellerServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("ProvidedServices")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DwellerService");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.HouseNoteholder", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("HouseNoteholders")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.Notes.Noteholder", "Noteholder")
                        .WithMany("HouseNoteholders")
                        .HasForeignKey("NoteholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Noteholder");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.Note", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerHouse.House", "House")
                        .WithMany("Notes")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId");

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.NoteholderNotes", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.Notes.Note", "Note")
                        .WithMany("NoteholderNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.Notes.Noteholder", "Noteholder")
                        .WithMany("NoteholderNotes")
                        .HasForeignKey("NoteholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("Noteholder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dwellers.Household.Domain.Entities.DwellerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerHouse.House", b =>
                {
                    b.Navigation("BorrowedItems");

                    b.Navigation("HouseConversations");

                    b.Navigation("HouseNoteholders");

                    b.Navigation("HouseUsers");

                    b.Navigation("Notes");

                    b.Navigation("ProvidedServices");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerItems.DwellerItem", b =>
                {
                    b.Navigation("BorrowedItems");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerServices.DwellerService", b =>
                {
                    b.Navigation("ProvidedServices");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.DwellerUser", b =>
                {
                    b.Navigation("DwellerMessages");

                    b.Navigation("HouseUsers");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.Note", b =>
                {
                    b.Navigation("NoteholderNotes");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.Entities.Notes.Noteholder", b =>
                {
                    b.Navigation("HouseNoteholders");

                    b.Navigation("NoteholderNotes");
                });

            modelBuilder.Entity("Dwellers.Household.Domain.ValueObjects.DwellerConversation", b =>
                {
                    b.Navigation("HouseConversations");
                });
#pragma warning restore 612, 618
        }
    }
}
