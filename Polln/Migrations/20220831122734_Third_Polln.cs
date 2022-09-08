using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Third_Polln : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GovernorCandidates_GovernorCandidateId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PresidentialCandidates_PresidentialCandidateId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PresidentialCandidateId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPresidentialCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsGovernorCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "GovernorCandidateId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GovernorCandidates_GovernorCandidateId",
                table: "Users",
                column: "GovernorCandidateId",
                principalTable: "GovernorCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PresidentialCandidates_PresidentialCandidateId",
                table: "Users",
                column: "PresidentialCandidateId",
                principalTable: "PresidentialCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GovernorCandidates_GovernorCandidateId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PresidentialCandidates_PresidentialCandidateId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PresidentialCandidateId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPresidentialCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsGovernorCandidateVoted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GovernorCandidateId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
