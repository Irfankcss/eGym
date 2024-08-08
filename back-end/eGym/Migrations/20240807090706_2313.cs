using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eGym.Migrations
{
    /// <inheritdoc />
    public partial class _2313 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Narudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Narudzba",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Narudzba");
        }
    }
}
