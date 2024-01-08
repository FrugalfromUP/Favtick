using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Favtick.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateCondidatecandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Condidates_CondidateId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "Condidates");

            migrationBuilder.RenameColumn(
                name: "CondidateId",
                table: "Skill",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_CondidateId",
                table: "Skill",
                newName: "IX_Skill_CandidateId");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    ResumeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Candidates_CandidateId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Skill",
                newName: "CondidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_CandidateId",
                table: "Skill",
                newName: "IX_Skill_CondidateId");

            migrationBuilder.CreateTable(
                name: "Condidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ResumeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condidates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Condidates_CondidateId",
                table: "Skill",
                column: "CondidateId",
                principalTable: "Condidates",
                principalColumn: "Id");
        }
    }
}
