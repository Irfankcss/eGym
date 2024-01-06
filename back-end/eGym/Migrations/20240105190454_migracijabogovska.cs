using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class migracijabogovska : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpstinaRodjenjaID",
                table: "Korisnik",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpstinaRodjenjaID",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
