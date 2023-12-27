using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Data.Migrations
{
    public partial class sinifolustur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guzergahs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kalkis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    varis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ucusSuresi = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guzergahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "koltukDuzenis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuzenAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiraSayisi = table.Column<int>(type: "int", nullable: false),
                    SutunSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_koltukDuzenis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "koltukSecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ucusId = table.Column<int>(type: "int", nullable: false),
                    koltukNumarasi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_koltukSecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ucakModelis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakMarkasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kapasite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucakModelis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ucus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guzergahId = table.Column<int>(type: "int", nullable: false),
                    ucakId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ucaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakModeliId = table.Column<int>(type: "int", nullable: false),
                    KoltukDuzeniId = table.Column<int>(type: "int", nullable: false),
                    KoltukSayisi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ucaks_koltukDuzenis_KoltukDuzeniId",
                        column: x => x.KoltukDuzeniId,
                        principalTable: "koltukDuzenis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ucaks_ucakModelis_UcakModeliId",
                        column: x => x.UcakModeliId,
                        principalTable: "ucakModelis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ucaks_KoltukDuzeniId",
                table: "ucaks",
                column: "KoltukDuzeniId");

            migrationBuilder.CreateIndex(
                name: "IX_ucaks_UcakModeliId",
                table: "ucaks",
                column: "UcakModeliId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guzergahs");

            migrationBuilder.DropTable(
                name: "koltukSecs");

            migrationBuilder.DropTable(
                name: "ucaks");

            migrationBuilder.DropTable(
                name: "ucus");

            migrationBuilder.DropTable(
                name: "koltukDuzenis");

            migrationBuilder.DropTable(
                name: "ucakModelis");
        }
    }
}
