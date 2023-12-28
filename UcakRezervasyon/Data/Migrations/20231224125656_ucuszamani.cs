using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class ucuszamani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ucusZamani",
                table: "ucus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ucusZamani",
                table: "ucus");
        }
    }
}
