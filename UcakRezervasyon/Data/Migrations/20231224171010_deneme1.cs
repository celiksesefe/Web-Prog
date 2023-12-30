using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tcNo",
                table: "koltukSecs",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tcNo",
                table: "koltukSecs");
        }
    }
}
