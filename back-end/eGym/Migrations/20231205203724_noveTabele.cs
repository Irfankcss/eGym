using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class noveTabele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_Grad_OpstinaRodjenjaID",
                table: "KorisnickiNalog");

            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_KorisnickiNalog_KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavjesti_KorisnickiNalog_AdminID",
                table: "Obavjesti");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiNalog_OpstinaRodjenjaID",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "AdminKod",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "OpstinaRodjenjaID",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "isClan",
                table: "KorisnickiNalog");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    AdminKod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isClan = table.Column<bool>(type: "bit", nullable: false),
                    OpstinaRodjenjaID = table.Column<int>(type: "int", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_OpstinaRodjenjaID",
                table: "Korisnik",
                column: "OpstinaRodjenjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavjesti_Admin_AdminID",
                table: "Obavjesti",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavjesti_Admin_AdminID",
                table: "Obavjesti");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.AddColumn<string>(
                name: "AdminKod",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "KorisnickiNalog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpstinaRodjenjaID",
                table: "KorisnickiNalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isClan",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_OpstinaRodjenjaID",
                table: "KorisnickiNalog",
                column: "OpstinaRodjenjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_Grad_OpstinaRodjenjaID",
                table: "KorisnickiNalog",
                column: "OpstinaRodjenjaID",
                principalTable: "Grad",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_KorisnickiNalog_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavjesti_KorisnickiNalog_AdminID",
                table: "Obavjesti",
                column: "AdminID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");
        }
    }
}
