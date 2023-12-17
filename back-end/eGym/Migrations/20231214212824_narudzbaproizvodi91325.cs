using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class narudzbaproizvodi91325 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
