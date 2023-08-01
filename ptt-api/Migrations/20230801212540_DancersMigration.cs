using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptt_api.Migrations
{
    /// <inheritdoc />
    public partial class DancersMigration : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_DanceClubs_AddressId",
                table: "DanceClubs",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dancers_DanceClubId",
                table: "Dancers",
                column: "DanceClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dancers");

            migrationBuilder.DropTable(
                name: "DanceClubs");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
