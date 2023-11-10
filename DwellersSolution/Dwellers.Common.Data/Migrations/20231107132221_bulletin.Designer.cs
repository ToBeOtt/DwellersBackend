﻿// <auto-generated />
using System;
using Dwellers.Common.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dwellers.Common.Data.Migrations
{
    [DbContext(typeof(DwellerDbContext))]
    [Migration("20231107132221_bulletin")]
    partial class bulletin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dwellers.Bulletins.Domain.Bulletins.Bulletin", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("_dateAdded")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateAdded");

                    b.Property<DateTime?>("_dateModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModified");

                    b.Property<bool>("_isArchived")
                        .HasColumnType("bit")
                        .HasColumnName("IsArchived");

                    b.Property<string>("_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Text");

                    b.Property<string>("_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<string>("_userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("Bulletins", (string)null);
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.DwellerConversationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DwellerConversations");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.DwellerMessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("DwellerMessages");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.HouseConversationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DwellerConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DwellerConversationId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseConversations");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerEvents.DwellerEventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventScope")
                        .HasColumnType("int");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("DwellerEvents");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerItems.BorrowedItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("ItemId");

                    b.ToTable("BorrowedItems");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerItems.DwellerItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

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

                    b.ToTable("DwellerItems");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerServices.DwellerServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceScope")
                        .HasColumnType("int");

                    b.Property<bool?>("ServiceStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DwellerServices");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerServices.ProvidedServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProvider")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("ServiceReturned")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProvidedServices");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.DwellerUserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.HouseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HousePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("HouseholdCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.HouseUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("HouseUsers");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteComment");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HouseEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IsCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IsModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotePriority")
                        .HasColumnType("int");

                    b.Property<int>("NoteScope")
                        .HasColumnType("int");

                    b.Property<int>("NoteStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HouseEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteHashtagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteHashtagEntity");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteSubscriber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteSubscriber");
                });

            modelBuilder.Entity("Dwellers.Bulletins.Domain.Bulletins.Bulletin", b =>
                {
                    b.OwnsOne("Dwellers.Bulletins.Domain.Bulletins.BulletinPriority", "_priority", b1 =>
                        {
                            b1.Property<Guid>("BulletinId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("_priority")
                                .HasColumnType("int")
                                .HasColumnName("Priority");

                            b1.HasKey("BulletinId");

                            b1.ToTable("Bulletins");

                            b1.WithOwner()
                                .HasForeignKey("BulletinId");
                        });

                    b.OwnsOne("Dwellers.Bulletins.Domain.Bulletins.BulletinScope", "_scope", b1 =>
                        {
                            b1.Property<Guid>("BulletinId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Visibility")
                                .HasColumnType("int")
                                .HasColumnName("Visibility");

                            b1.HasKey("BulletinId");

                            b1.ToTable("BulletinScope", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BulletinId");

                            b1.OwnsMany("Dwellers.Bulletins.Domain.Bulletins.ScopedHouse", "_listOfHouses", b2 =>
                                {
                                    b2.Property<Guid>("ScopeId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<int>("Id"));

                                    b2.Property<Guid>("_scopedHouseId")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("HouseId");

                                    b2.HasKey("ScopeId", "Id");

                                    b2.ToTable("ScopedHouse");

                                    b2.WithOwner()
                                        .HasForeignKey("ScopeId");
                                });

                            b1.Navigation("_listOfHouses");
                        });

                    b.OwnsOne("Dwellers.Bulletins.Domain.Bulletins.BulletinStatus", "_status", b1 =>
                        {
                            b1.Property<Guid>("BulletinId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("_status")
                                .HasColumnType("int")
                                .HasColumnName("Status");

                            b1.HasKey("BulletinId");

                            b1.ToTable("Bulletins");

                            b1.WithOwner()
                                .HasForeignKey("BulletinId");
                        });

                    b.OwnsMany("Dwellers.Bulletins.Domain.Bulletins.BulletinTag", "_tags", b1 =>
                        {
                            b1.Property<Guid>("_bulletinId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("BulletinId");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("_tag")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Tag");

                            b1.HasKey("_bulletinId", "Id");

                            b1.ToTable("BulletinTag");

                            b1.WithOwner()
                                .HasForeignKey("_bulletinId")
                                .HasConstraintName("FK_BulletinTag_BulletinId");
                        });

                    b.Navigation("_priority");

                    b.Navigation("_scope");

                    b.Navigation("_status");

                    b.Navigation("_tags");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.DwellerMessageEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.DwellerChat.DwellerConversationEntity", "Conversation")
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.Household.DwellerUserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.HouseConversationEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.DwellerChat.DwellerConversationEntity", "DwellerConversation")
                        .WithMany("HouseConversations")
                        .HasForeignKey("DwellerConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DwellerConversation");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerEvents.DwellerEventEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.Household.DwellerUserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerItems.BorrowedItemEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany("BorrowedItems")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.DwellerItems.DwellerItemEntity", "Item")
                        .WithMany("BorrowedItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerServices.ProvidedServiceEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany("ProvidedServices")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.DwellerServices.DwellerServiceEntity", "Service")
                        .WithMany("ProvidedServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.HouseUserEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany("HouseUsers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.Household.DwellerUserEntity", "User")
                        .WithMany("HouseUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteComment", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Notes.NoteEntity", "Note")
                        .WithMany("NoteComments")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", null)
                        .WithMany("Notes")
                        .HasForeignKey("HouseEntityId");

                    b.HasOne("Dwellers.Common.Data.Models.Household.DwellerUserEntity", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteHashtagEntity", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Notes.NoteEntity", "Note")
                        .WithMany("NoteHashtagEntities")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteSubscriber", b =>
                {
                    b.HasOne("Dwellers.Common.Data.Models.Household.HouseEntity", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dwellers.Common.Data.Models.Notes.NoteEntity", "Note")
                        .WithMany("NoteSubscribers")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerChat.DwellerConversationEntity", b =>
                {
                    b.Navigation("HouseConversations");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerItems.DwellerItemEntity", b =>
                {
                    b.Navigation("BorrowedItems");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.DwellerServices.DwellerServiceEntity", b =>
                {
                    b.Navigation("ProvidedServices");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.DwellerUserEntity", b =>
                {
                    b.Navigation("HouseUsers");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Household.HouseEntity", b =>
                {
                    b.Navigation("BorrowedItems");

                    b.Navigation("HouseUsers");

                    b.Navigation("Notes");

                    b.Navigation("ProvidedServices");
                });

            modelBuilder.Entity("Dwellers.Common.Data.Models.Notes.NoteEntity", b =>
                {
                    b.Navigation("NoteComments");

                    b.Navigation("NoteHashtagEntities");

                    b.Navigation("NoteSubscribers");
                });
#pragma warning restore 612, 618
        }
    }
}