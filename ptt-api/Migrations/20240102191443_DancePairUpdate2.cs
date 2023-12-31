﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ptt_api.Migrations
{
    /// <inheritdoc />
    public partial class DancePairUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                table: "DancePairs");

            migrationBuilder.AlterColumn<int>(
                name: "DanceCompetitionCategoryId",
                table: "DancePairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                table: "DancePairs",
                column: "DanceCompetitionCategoryId",
                principalTable: "DanceCompetitionCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                table: "DancePairs");

            migrationBuilder.AlterColumn<int>(
                name: "DanceCompetitionCategoryId",
                table: "DancePairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DancePairs_DanceCompetitionCategories_DanceCompetitionCategoryId",
                table: "DancePairs",
                column: "DanceCompetitionCategoryId",
                principalTable: "DanceCompetitionCategories",
                principalColumn: "Id");
        }
    }
}
