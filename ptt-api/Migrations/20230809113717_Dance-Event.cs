using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptt_api.Migrations
{
    /// <inheritdoc />
    public partial class DanceEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DancePairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DancerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DancePartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PairDanceClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PairNumberofPoints = table.Column<int>(type: "int", nullable: false),
                    DancePairClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanceCompetitionCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DancePairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                        column: x => x.DanceCompetitionCategoryId,
                        principalTable: "DanceCompetitionCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanceCompetitionCategories_DanceEventId",
                table: "DanceCompetitionCategories",
                column: "DanceEventId");

            migrationBuilder.CreateIndex(
                name: "IX_DancePairs_DanceCompetitionCategoryId",
                table: "DancePairs",
                column: "DanceCompetitionCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DancePairs");

            migrationBuilder.DropTable(
                name: "DanceCompetitionCategories");

            migrationBuilder.DropTable(
                name: "DanceEvents");
        }
    }
}
