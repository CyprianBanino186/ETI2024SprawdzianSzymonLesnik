using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprawdzianSzymonLesnik.Migrations
{
    /// <inheritdoc />
    public partial class init2222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nauczyciel",
                columns: table => new
                {
                    NauczycielId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresZamieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nauczyciel", x => x.NauczycielId);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKursu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NauczycielId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.KursId);
                    table.ForeignKey(
                        name: "FK_Kurs_Nauczyciel_NauczycielId1",
                        column: x => x.NauczycielId1,
                        principalTable: "Nauczyciel",
                        principalColumn: "NauczycielId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_NauczycielId1",
                table: "Kurs",
                column: "NauczycielId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Nauczyciel");
        }
    }
}
