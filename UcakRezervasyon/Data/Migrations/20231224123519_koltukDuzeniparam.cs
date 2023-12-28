using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class koltukDuzeniparam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SutunSayisi",
                table: "koltukDuzenis",
                newName: "SolSira");

            migrationBuilder.RenameColumn(
                name: "SiraSayisi",
                table: "koltukDuzenis",
                newName: "SağSira");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SolSira",
                table: "koltukDuzenis",
                newName: "SutunSayisi");

            migrationBuilder.RenameColumn(
                name: "SağSira",
                table: "koltukDuzenis",
                newName: "SiraSayisi");
        }
    }
}
