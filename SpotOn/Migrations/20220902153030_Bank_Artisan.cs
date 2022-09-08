using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Bank_Artisan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Users_UserId",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Banks",
                newName: "ArtisanId");

            migrationBuilder.RenameIndex(
                name: "IX_Banks_UserId",
                table: "Banks",
                newName: "IX_Banks_ArtisanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Artisans_ArtisanId",
                table: "Banks",
                column: "ArtisanId",
                principalTable: "Artisans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Artisans_ArtisanId",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "ArtisanId",
                table: "Banks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Banks_ArtisanId",
                table: "Banks",
                newName: "IX_Banks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Users_UserId",
                table: "Banks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
