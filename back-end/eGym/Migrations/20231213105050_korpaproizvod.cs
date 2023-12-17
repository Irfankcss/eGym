using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class korpaproizvod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Korpa_KorpaID",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_KorpaID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "KorpaID",
                table: "Proizvod");

            migrationBuilder.CreateTable(
                name: "KorpaProizvod",
                columns: table => new
                {
                    KorpaProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorpaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorpaProizvod", x => x.KorpaProizvodID);
                    table.ForeignKey(
                        name: "FK_KorpaProizvod_Korpa_KorpaID",
                        column: x => x.KorpaID,
                        principalTable: "Korpa",
                        principalColumn: "KorpaID");
                    table.ForeignKey(
                        name: "FK_KorpaProizvod_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorpaProizvod_KorpaID",
                table: "KorpaProizvod",
                column: "KorpaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorpaProizvod_ProizvodID",
                table: "KorpaProizvod",
                column: "ProizvodID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorpaProizvod");

            migrationBuilder.AddColumn<int>(
                name: "KorpaID",
                table: "Proizvod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KorpaID",
                table: "Proizvod",
                column: "KorpaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Korpa_KorpaID",
                table: "Proizvod",
                column: "KorpaID",
                principalTable: "Korpa",
                principalColumn: "KorpaID");
        }
    }
}
