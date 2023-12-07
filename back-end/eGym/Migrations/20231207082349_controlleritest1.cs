using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class controlleritest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Narudzba_NarudzbaId",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_NarudzbaId",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "NarudzbaId",
                table: "Proizvod");

            migrationBuilder.CreateTable(
                name: "NarudzbaProizvod",
                columns: table => new
                {
                    NarudzbaProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaProizvod", x => x.NarudzbaProizvodID);
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_NarudzbaId",
                table: "NarudzbaProizvod",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_ProizvodId",
                table: "NarudzbaProizvod",
                column: "ProizvodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarudzbaProizvod");

            migrationBuilder.AddColumn<int>(
                name: "NarudzbaId",
                table: "Proizvod",
                type: "int",
                nullable: true);

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
    }
}
