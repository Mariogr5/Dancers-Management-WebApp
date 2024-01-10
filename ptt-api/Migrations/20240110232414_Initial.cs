using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptt_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanceEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompetition = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanceClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceClubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanceClubs_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanceCompetitionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDanceClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanceEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceCompetitionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanceCompetitionCategories_DanceEvents_DanceEventId",
                        column: x => x.DanceEventId,
                        principalTable: "DanceEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Danceclass = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "H"),
                    NumberofPoints = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DancePartnerId = table.Column<int>(type: "int", nullable: true),
                    DancePartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanceClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dancers_DanceClubs_DanceClubId",
                        column: x => x.DanceClubId,
                        principalTable: "DanceClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DancePairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DancerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DancePartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DancerId = table.Column<int>(type: "int", nullable: false),
                    DancePartnerId = table.Column<int>(type: "int", nullable: false),
                    PairDanceClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PairNumberofPoints = table.Column<int>(type: "int", nullable: false),
                    DancePairClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanceClubId = table.Column<int>(type: "int", nullable: false),
                    DanceCompetitionCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DancePairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                        column: x => x.DanceCompetitionCategoryId,
                        principalTable: "DanceCompetitionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanceClubs_AddressId",
                table: "DanceClubs",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanceCompetitionCategories_DanceEventId",
                table: "DanceCompetitionCategories",
                column: "DanceEventId");

            migrationBuilder.CreateIndex(
                name: "IX_DancePairs_DanceCompetitionCategoryId",
                table: "DancePairs",
                column: "DanceCompetitionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dancers_DanceClubId",
                table: "Dancers",
                column: "DanceClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DancePairs");

            migrationBuilder.DropTable(
                name: "Dancers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DanceCompetitionCategories");

            migrationBuilder.DropTable(
                name: "DanceClubs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "DanceEvents");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
