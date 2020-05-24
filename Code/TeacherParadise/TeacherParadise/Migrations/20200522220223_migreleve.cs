using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherParadise.Migrations
{
    public partial class migreleve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    SurName = table.Column<string>(maxLength: 20, nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    NiveauEtude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CReservationCoursCollectifs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRes = table.Column<DateTime>(nullable: false),
                    CEleveID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CReservationCoursCollectifs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CReservationCoursCollectifs_Eleves_CEleveID",
                        column: x => x.CEleveID,
                        principalTable: "Eleves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CReservationCoursCollectifs_CEleveID",
                table: "CReservationCoursCollectifs",
                column: "CEleveID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CReservationCoursCollectifs");

            migrationBuilder.DropTable(
                name: "Eleves");
        }
    }
}
