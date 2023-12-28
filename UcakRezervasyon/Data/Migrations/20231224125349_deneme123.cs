using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class deneme123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "guzergahs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "guzergahs");
        }
    }
}
