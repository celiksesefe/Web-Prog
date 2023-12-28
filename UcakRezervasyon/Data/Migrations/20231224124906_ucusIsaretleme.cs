using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class ucusIsaretleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ucus_guzergahId",
                table: "ucus",
                column: "guzergahId");

            migrationBuilder.CreateIndex(
                name: "IX_ucus_ucakId",
                table: "ucus",
                column: "ucakId");

            migrationBuilder.AddForeignKey(
                name: "FK_ucus_guzergahs_guzergahId",
                table: "ucus",
                column: "guzergahId",
                principalTable: "guzergahs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ucus_ucaks_ucakId",
                table: "ucus",
                column: "ucakId",
                principalTable: "ucaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ucus_guzergahs_guzergahId",
                table: "ucus");

            migrationBuilder.DropForeignKey(
                name: "FK_ucus_ucaks_ucakId",
                table: "ucus");

            migrationBuilder.DropIndex(
                name: "IX_ucus_guzergahId",
                table: "ucus");

            migrationBuilder.DropIndex(
                name: "IX_ucus_ucakId",
                table: "ucus");
        }
    }
}
