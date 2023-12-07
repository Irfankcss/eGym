using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class novetabeleI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    BrendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivBrenda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.BrendId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Radnik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Radnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    KolicinaNaSkladistu = table.Column<int>(type: "int", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrendID = table.Column<int>(type: "int", nullable: false),
                    Velicina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: false),
                    popust = table.Column<int>(type: "int", nullable: true),
                    isIzdvojen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Brend_BrendID",
                        column: x => x.BrendID,
                        principalTable: "Brend",
                        principalColumn: "BrendId");
                    table.ForeignKey(
                        name: "FK_Proizvod_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_BrendID",
                table: "Proizvod",
                column: "BrendID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Radnik_GradID",
                table: "Radnik",
                column: "GradID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
