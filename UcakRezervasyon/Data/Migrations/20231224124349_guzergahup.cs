using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class guzergahup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mesafeKm",
                table: "guzergahs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mesafeKm",
                table: "guzergahs");
        }
    }
}
