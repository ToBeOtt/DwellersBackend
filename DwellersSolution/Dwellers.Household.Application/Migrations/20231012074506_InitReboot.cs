using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dwellers.Household.Migrations
{
    /// <inheritdoc />
    public partial class InitReboot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HouseholdSchema");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerConversations",
                schema: "HouseholdSchema",
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
                name: "DwellerItems",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemScope = table.Column<int>(type: "int", nullable: false),
                    ItemPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ItemStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DwellerServices",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceScope = table.Column<int>(type: "int", nullable: false),
                    ServiceStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseholdCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HousePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Noteholders",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    NoteholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: true),
                    NoteholderScope = table.Column<int>(type: "int", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noteholders", x => x.NoteholderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DwellerMessages",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellerMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DwellerMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DwellerMessages_DwellerConversations_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_DwellerItems_DwellerItemId",
                        column: x => x.DwellerItemId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "DwellerItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventScope = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    EventCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseConversations",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseConversations_DwellerConversations_DwellerConversationId",
                        column: x => x.DwellerConversationId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "DwellerConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseConversations_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseUsers",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseUsers_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteStatus = table.Column<int>(type: "int", nullable: true),
                    NotePriority = table.Column<int>(type: "int", nullable: true),
                    NoteScope = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    NoteCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedServices",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DwellerServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsProvider = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceReturned = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_DwellerServices_DwellerServiceId",
                        column: x => x.DwellerServiceId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "DwellerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvidedServices_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseNoteholders",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNoteholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseNoteholders_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseNoteholders_Noteholders_NoteholderId",
                        column: x => x.NoteholderId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Noteholders",
                        principalColumn: "NoteholderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteholderNotes",
                schema: "HouseholdSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteholderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteholderNotes_Noteholders_NoteholderId",
                        column: x => x.NoteholderId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Noteholders",
                        principalColumn: "NoteholderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteholderNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalSchema: "HouseholdSchema",
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "HouseholdSchema",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "HouseholdSchema",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "HouseholdSchema",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "HouseholdSchema",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "HouseholdSchema",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "HouseholdSchema",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "HouseholdSchema",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_DwellerItemId",
                schema: "HouseholdSchema",
                table: "BorrowedItems",
                column: "DwellerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_HouseId",
                schema: "HouseholdSchema",
                table: "BorrowedItems",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_ConversationId",
                schema: "HouseholdSchema",
                table: "DwellerMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellerMessages_UserId",
                schema: "HouseholdSchema",
                table: "DwellerMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_HouseId",
                schema: "HouseholdSchema",
                table: "Events",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                schema: "HouseholdSchema",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_DwellerConversationId",
                schema: "HouseholdSchema",
                table: "HouseConversations",
                column: "DwellerConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseConversations_HouseId",
                schema: "HouseholdSchema",
                table: "HouseConversations",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNoteholders_HouseId",
                schema: "HouseholdSchema",
                table: "HouseNoteholders",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNoteholders_NoteholderId",
                schema: "HouseholdSchema",
                table: "HouseNoteholders",
                column: "NoteholderId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_HouseId",
                schema: "HouseholdSchema",
                table: "HouseUsers",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_UserId",
                schema: "HouseholdSchema",
                table: "HouseUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteholderNotes_NoteholderId",
                schema: "HouseholdSchema",
                table: "NoteholderNotes",
                column: "NoteholderId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteholderNotes_NoteId",
                schema: "HouseholdSchema",
                table: "NoteholderNotes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HouseId",
                schema: "HouseholdSchema",
                table: "Notes",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                schema: "HouseholdSchema",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_DwellerServiceId",
                schema: "HouseholdSchema",
                table: "ProvidedServices",
                column: "DwellerServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServices_HouseId",
                schema: "HouseholdSchema",
                table: "ProvidedServices",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "BorrowedItems",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "DwellerMessages",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "HouseConversations",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "HouseNoteholders",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "HouseUsers",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "NoteholderNotes",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "ProvidedServices",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "DwellerItems",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "DwellerConversations",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "Noteholders",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "DwellerServices",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "HouseholdSchema");

            migrationBuilder.DropTable(
                name: "Houses",
                schema: "HouseholdSchema");
        }
    }
}
