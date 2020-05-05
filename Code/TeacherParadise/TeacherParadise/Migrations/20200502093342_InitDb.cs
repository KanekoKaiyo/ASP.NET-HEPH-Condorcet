using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherParadise.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    SurName = table.Column<string>(maxLength: 20, nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    ProfesseurID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conges_Professeurs_ProfesseurID",
                        column: x => x.ProfesseurID,
                        principalTable: "Professeurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursRemediations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false),
                    EndHour = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ProfesseurID = table.Column<int>(nullable: true)
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: false),
                    Niveau = table.Column<string>(nullable: false),
                    CProfesseurID = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CoursCollectifs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MatieresID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false),
                    MaxStudent = table.Column<int>(nullable: false),
                    CurrentStudent = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProfesseurID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursCollectifs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoursCollectifs_Matieres_MatieresID",
                        column: x => x.MatieresID,
                        principalTable: "Matieres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursCollectifs_Professeurs_ProfesseurID",
                        column: x => x.ProfesseurID,
                        principalTable: "Professeurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conges_ProfesseurID",
                table: "Conges",
                column: "ProfesseurID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursCollectifs_MatieresID",
                table: "CoursCollectifs",
                column: "MatieresID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursCollectifs_ProfesseurID",
                table: "CoursCollectifs",
                column: "ProfesseurID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursRemediations_ProfesseurID",
                table: "CoursRemediations",
                column: "ProfesseurID");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_CProfesseurID",
                table: "Matieres",
                column: "CProfesseurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "CoursCollectifs");

            migrationBuilder.DropTable(
                name: "CoursRemediations");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Professeurs");
        }
    }
}
