using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Favtick.Core.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascadeConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_CandidateId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId1",
                table: "Skills",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CandidateId1",
                table: "Skills",
                column: "CandidateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_CandidateId",
                table: "Skills",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_CandidateId1",
                table: "Skills",
                column: "CandidateId1",
                principalTable: "Candidates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_CandidateId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Candidates_CandidateId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CandidateId1",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CandidateId1",
                table: "Skills");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Candidates_CandidateId",
                table: "Skills",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }
    }
}
