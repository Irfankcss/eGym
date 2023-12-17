using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class poslananarudzba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoslanaNarudzba_Narudzba_Id",
                table: "PoslanaNarudzba");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoslanaNarudzba",
                table: "PoslanaNarudzba");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PoslanaNarudzba",
                newName: "NarudzbaID");

            migrationBuilder.AddColumn<int>(
                name: "PoslanaNarudzbaID",
                table: "PoslanaNarudzba",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "isPoslana",
                table: "Narudzba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoslanaNarudzba",
                table: "PoslanaNarudzba",
                column: "PoslanaNarudzbaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PoslanaNarudzba",
                table: "PoslanaNarudzba");

            migrationBuilder.DropColumn(
                name: "PoslanaNarudzbaID",
                table: "PoslanaNarudzba");

            migrationBuilder.DropColumn(
                name: "isPoslana",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "NarudzbaID",
                table: "PoslanaNarudzba",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoslanaNarudzba",
                table: "PoslanaNarudzba",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoslanaNarudzba_Narudzba_Id",
                table: "PoslanaNarudzba",
                column: "Id",
                principalTable: "Narudzba",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
