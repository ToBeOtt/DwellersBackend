﻿// <auto-generated />
using System;
using Dwellers.Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dwellers.Chat.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    partial class ChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.DwellerConversation", b =>
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

                    b.ToTable("DwellerConversations");
                });

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.DwellerMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DwellerConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DwellerConversationId");

                    b.ToTable("DwellerMessages");
                });

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.HouseConversation", b =>
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

                    b.ToTable("HouseConversations");
                });

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.DwellerMessage", b =>
                {
                    b.HasOne("Dwellers.Chat.Domain.Entities.DwellerConversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("DwellerConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");
                });

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.HouseConversation", b =>
                {
                    b.HasOne("Dwellers.Chat.Domain.Entities.DwellerConversation", "DwellerConversation")
                        .WithMany("HouseConversations")
                        .HasForeignKey("DwellerConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DwellerConversation");
                });

            modelBuilder.Entity("Dwellers.Chat.Domain.Entities.DwellerConversation", b =>
                {
                    b.Navigation("HouseConversations");
                });
#pragma warning restore 612, 618
        }
    }
}
