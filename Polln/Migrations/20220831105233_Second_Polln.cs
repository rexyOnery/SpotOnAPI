using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Second_Polln : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GovernorCandidateId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsGovernorCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPresidentialCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PresidentialCandidateId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GovernorCandidateId",
                table: "Users",
                column: "GovernorCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PresidentialCandidateId",
                table: "Users",
                column: "PresidentialCandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GovernorCandidates_GovernorCandidateId",
                table: "Users",
                column: "GovernorCandidateId",
                principalTable: "GovernorCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PresidentialCandidates_PresidentialCandidateId",
                table: "Users",
                column: "PresidentialCandidateId",
                principalTable: "PresidentialCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GovernorCandidates_GovernorCandidateId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PresidentialCandidates_PresidentialCandidateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GovernorCandidateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PresidentialCandidateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GovernorCandidateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsGovernorCandidateVoted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPresidentialCandidateVoted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PresidentialCandidateId",
                table: "Users");
        }
    }
}
