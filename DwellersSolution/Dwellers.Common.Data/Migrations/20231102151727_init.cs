using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DwellerConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerConversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemScope = table.Column<int>(type: "int", nullable: false),
                    ItemPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ItemStatus = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceScope = table.Column<int>(type: "int", nullable: false),
                    ServiceStatus = table.Column<bool>(type: "bit", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseholdCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noteholders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: true),
                    NoteholderScope = table.Column<int>(type: "int", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noteholders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_DwellerItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "DwellerItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseConversations_DwellerConversations_DwellerConversationId",
                        column: x => x.DwellerConversationId,
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseConversations_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsProvider = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceReturned = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_DwellerServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "DwellerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseNoteholders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNoteholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseNoteholders_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseNoteholders_Noteholders_NoteholderId",
                        column: x => x.NoteholderId,
                        principalTable: "Noteholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellerEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventScope = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellerEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DwellerMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_DwellerConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseUsers_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteStatus = table.Column<int>(type: "int", nullable: true),
                    NotePriority = table.Column<int>(type: "int", nullable: true),
                    NoteScope = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteholderNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    IsCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteholderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteholderNotes_Noteholders_NoteholderId",
                        column: x => x.NoteholderId,
                        principalTable: "Noteholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteholderNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_HouseId",
                table: "BorrowedItems",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_ItemId",
                table: "BorrowedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_HouseId",
                table: "DwellerEvents",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerEvents_UserId",
                table: "DwellerEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_ConversationId",
                table: "DwellerMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_UserId",
                table: "DwellerMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_DwellerConversationId",
                table: "HouseConversations",
                column: "DwellerConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_HouseId",
                table: "HouseConversations",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNoteholders_HouseId",
                table: "HouseNoteholders",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNoteholders_NoteholderId",
                table: "HouseNoteholders",
                column: "NoteholderId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_HouseId",
                table: "HouseUsers",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_UserId",
                table: "HouseUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteholderNotes_NoteholderId",
                table: "NoteholderNotes",
                column: "NoteholderId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteholderNotes_NoteId",
                table: "NoteholderNotes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HouseId",
                table: "Notes",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_HouseId",
                table: "ProvidedServices",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_ServiceId",
                table: "ProvidedServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedItems");

            migrationBuilder.DropTable(
                name: "DwellerEvents");

            migrationBuilder.DropTable(
                name: "DwellerMessages");

            migrationBuilder.DropTable(
                name: "HouseConversations");

            migrationBuilder.DropTable(
                name: "HouseNoteholders");

            migrationBuilder.DropTable(
                name: "HouseUsers");

            migrationBuilder.DropTable(
                name: "NoteholderNotes");

            migrationBuilder.DropTable(
                name: "ProvidedServices");

            migrationBuilder.DropTable(
                name: "DwellerItems");

            migrationBuilder.DropTable(
                name: "DwellerConversations");

            migrationBuilder.DropTable(
                name: "Noteholders");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "DwellerServices");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
