using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherParadise.Migrations
{
    public partial class UpdateDatabase01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursCollectifs_Matieres_MatieresID",
                table: "CoursCollectifs");

            migrationBuilder.DropTable(
                name: "CoursRemediations");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropIndex(
                name: "IX_CoursCollectifs_MatieresID",
                table: "CoursCollectifs");

            migrationBuilder.DropColumn(
                name: "MatieresID",
                table: "CoursCollectifs");

            migrationBuilder.AddColumn<string>(
                name: "Matieres",
                table: "CoursCollectifs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "CoursCollectifs",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matieres",
                table: "CoursCollectifs");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "CoursCollectifs");

            migrationBuilder.AddColumn<int>(
                name: "MatieresID",
                table: "CoursCollectifs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoursRemediations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfesseurID = table.Column<int>(type: "int", nullable: true),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursRemediations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoursRemediations_Professeurs_ProfesseurID",
                        column: x => x.ProfesseurID,
                        principalTable: "Professeurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CProfesseurID = table.Column<int>(type: "int", nullable: true),
                    Niveau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matieres_Professeurs_CProfesseurID",
                        column: x => x.CProfesseurID,
                        principalTable: "Professeurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursCollectifs_MatieresID",
                table: "CoursCollectifs",
                column: "MatieresID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursRemediations_ProfesseurID",
                table: "CoursRemediations",
                column: "ProfesseurID");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_CProfesseurID",
                table: "Matieres",
                column: "CProfesseurID");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursCollectifs_Matieres_MatieresID",
                table: "CoursCollectifs",
                column: "MatieresID",
                principalTable: "Matieres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
