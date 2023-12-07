using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class novetabele3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoslanaNarudzba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DatumSlanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsporuke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPreuzeta = table.Column<bool>(type: "bit", nullable: false),
                    isIsporucena = table.Column<bool>(type: "bit", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoslanaNarudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoslanaNarudzba_Narudzba_Id",
                        column: x => x.Id,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoslanaNarudzba_Radnik_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoslanaNarudzba_RadnikID",
                table: "PoslanaNarudzba",
                column: "RadnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoslanaNarudzba");
        }
    }
}
