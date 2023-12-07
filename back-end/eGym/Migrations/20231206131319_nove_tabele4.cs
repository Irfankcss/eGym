using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class novetabele4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorpaID",
                table: "Proizvod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Korpa",
                columns: table => new
                {
                    KorpaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Vrijednost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpa", x => x.KorpaID);
                    table.ForeignKey(
                        name: "FK_Korpa_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KorpaID",
                table: "Proizvod",
                column: "KorpaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KorisnikID",
                table: "Korpa",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Korpa_KorpaID",
                table: "Proizvod",
                column: "KorpaID",
                principalTable: "Korpa",
                principalColumn: "KorpaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Korpa_KorpaID",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_KorpaID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "KorpaID",
                table: "Proizvod");
        }
    }
}
