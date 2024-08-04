using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaProizvoda",
                table: "KorpaProizvod");

            migrationBuilder.AddColumn<int>(
                name: "SlikaProizvodaId",
                table: "KorpaProizvod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KorpaProizvod_SlikaProizvodaId",
                table: "KorpaProizvod",
                column: "SlikaProizvodaId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorpaProizvod_Slika_SlikaProizvodaId",
                table: "KorpaProizvod",
                column: "SlikaProizvodaId",
                principalTable: "Slika",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorpaProizvod_Slika_SlikaProizvodaId",
                table: "KorpaProizvod");

            migrationBuilder.DropIndex(
                name: "IX_KorpaProizvod_SlikaProizvodaId",
                table: "KorpaProizvod");

            migrationBuilder.DropColumn(
                name: "SlikaProizvodaId",
                table: "KorpaProizvod");

            migrationBuilder.AddColumn<string>(
                name: "SlikaProizvoda",
                table: "KorpaProizvod",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
