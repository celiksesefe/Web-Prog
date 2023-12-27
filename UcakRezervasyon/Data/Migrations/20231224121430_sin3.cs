using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class sin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_koltukSecs_ucusId",
                table: "koltukSecs",
                column: "ucusId");

            migrationBuilder.AddForeignKey(
                name: "FK_koltukSecs_ucus_ucusId",
                table: "koltukSecs",
                column: "ucusId",
                principalTable: "ucus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_koltukSecs_ucus_ucusId",
                table: "koltukSecs");

            migrationBuilder.DropIndex(
                name: "IX_koltukSecs_ucusId",
                table: "koltukSecs");
        }
    }
}
