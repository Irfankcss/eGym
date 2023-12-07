using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class Narudzbatest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NarudzbaId",
                table: "Proizvod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isOdobrena = table.Column<bool>(type: "bit", nullable: false),
                    Vrijednost = table.Column<double>(type: "float", nullable: false),
                    Popust = table.Column<double>(type: "float", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_NarudzbaId",
                table: "Proizvod",
                column: "NarudzbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Narudzba_NarudzbaId",
                table: "Proizvod",
                column: "NarudzbaId",
                principalTable: "Narudzba",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Narudzba_NarudzbaId",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_NarudzbaId",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "NarudzbaId",
                table: "Proizvod");
        }
    }
}
