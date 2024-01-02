using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptt_api.Migrations
{
    /// <inheritdoc />
    public partial class DancePairUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DancePartnerId",
                table: "DancePairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DancerId",
                table: "DancePairs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DancePartnerId",
                table: "DancePairs");

            migrationBuilder.DropColumn(
                name: "DancerId",
                table: "DancePairs");
        }
    }
}
