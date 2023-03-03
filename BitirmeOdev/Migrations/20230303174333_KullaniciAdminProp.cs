using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeOdev.Migrations
{
    public partial class KullaniciAdminProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Kullanici",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Kullanici");
        }
    }
}
