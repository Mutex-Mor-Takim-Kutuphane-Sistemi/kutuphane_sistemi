using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Purple_Kutphane_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class AddKullaniciReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciTempId",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciTempId",
                table: "Kullanicilar");
        }
    }
}
