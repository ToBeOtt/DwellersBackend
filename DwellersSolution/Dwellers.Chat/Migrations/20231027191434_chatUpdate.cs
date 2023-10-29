using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Chat.Migrations
{
    /// <inheritdoc />
    public partial class chatUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseConversations_DwellerConversations_DwellerConversationId1",
                table: "HouseConversations");

            migrationBuilder.DropIndex(
                name: "IX_HouseConversations_DwellerConversationId1",
                table: "HouseConversations");

            migrationBuilder.DropColumn(
                name: "DwellerConversationId1",
                table: "HouseConversations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DwellerConversationId1",
                table: "HouseConversations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_DwellerConversationId1",
                table: "HouseConversations",
                column: "DwellerConversationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseConversations_DwellerConversations_DwellerConversationId1",
                table: "HouseConversations",
                column: "DwellerConversationId1",
                principalTable: "DwellerConversations",
                principalColumn: "Id");
        }
    }
}
