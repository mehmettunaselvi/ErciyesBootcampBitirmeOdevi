using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeOdev.Migrations
{
    public partial class UrunListeModelEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Liste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liste_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gorsel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListUrun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListeId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListUrun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListUrun_Liste_ListeId",
                        column: x => x.ListeId,
                        principalTable: "Liste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListUrun_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Liste_KullaniciId",
                table: "Liste",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_ListUrun_ListeId",
                table: "ListUrun",
                column: "ListeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListUrun_UrunId",
                table: "ListUrun",
                column: "UrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListUrun");

            migrationBuilder.DropTable(
                name: "Liste");

            migrationBuilder.DropTable(
                name: "Urun");
        }
    }
}
