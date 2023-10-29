using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Chat.Migrations
{
    /// <inheritdoc />
    public partial class ChatModuleInit : Migration
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerConversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseConversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerConversationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_HouseConversations_DwellerConversations_DwellerConversationId1",
                        column: x => x.DwellerConversationId1,
                        principalTable: "DwellerConversations",
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_HouseConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "HouseConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_ConversationId",
                table: "DwellerMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_DwellerConversationId",
                table: "HouseConversations",
                column: "DwellerConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_DwellerConversationId1",
                table: "HouseConversations",
                column: "DwellerConversationId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DwellerMessages");

            migrationBuilder.DropTable(
                name: "HouseConversations");

            migrationBuilder.DropTable(
                name: "DwellerConversations");
        }
    }
}
