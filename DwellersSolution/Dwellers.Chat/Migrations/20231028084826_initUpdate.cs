using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Chat.Migrations
{
    /// <inheritdoc />
    public partial class initUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DwellerMessages_HouseConversations_ConversationId",
                table: "DwellerMessages");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "DwellerMessages",
                newName: "DwellerConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_DwellerMessages_ConversationId",
                table: "DwellerMessages",
                newName: "IX_DwellerMessages_DwellerConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DwellerMessages_DwellerConversations_DwellerConversationId",
                table: "DwellerMessages",
                column: "DwellerConversationId",
                principalTable: "DwellerConversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DwellerMessages_DwellerConversations_DwellerConversationId",
                table: "DwellerMessages");

            migrationBuilder.RenameColumn(
                name: "DwellerConversationId",
                table: "DwellerMessages",
                newName: "ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_DwellerMessages_DwellerConversationId",
                table: "DwellerMessages",
                newName: "IX_DwellerMessages_ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DwellerMessages_HouseConversations_ConversationId",
                table: "DwellerMessages",
                column: "ConversationId",
                principalTable: "HouseConversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
