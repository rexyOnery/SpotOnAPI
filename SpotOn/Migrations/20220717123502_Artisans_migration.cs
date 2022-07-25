using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Artisans_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Artisans");

            migrationBuilder.AddColumn<int>(
                name: "LocalAreaId",
                table: "Artisans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artisans_LocalAreaId",
                table: "Artisans",
                column: "LocalAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisans_LocalAreas_LocalAreaId",
                table: "Artisans",
                column: "LocalAreaId",
                principalTable: "LocalAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisans_LocalAreas_LocalAreaId",
                table: "Artisans");

            migrationBuilder.DropIndex(
                name: "IX_Artisans_LocalAreaId",
                table: "Artisans");

            migrationBuilder.DropColumn(
                name: "LocalAreaId",
                table: "Artisans");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Artisans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
