using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Purple_Kutphane_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class addReferences2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapAlimlari_Kitaplar_kitap_id",
                table: "KitapAlimlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapAlimlari_Uyeler_uye_id",
                table: "KitapAlimlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Gorevliler_gorevli_id",
                table: "KitapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Kitaplar_kitap_id",
                table: "KitapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Uyeler_uye_id",
                table: "KitapTalepleri");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri",
                column: "gorevli_id",
                principalTable: "Gorevliler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapAlimlari_Kitaplar_kitap_id",
                table: "KitapAlimlari",
                column: "kitap_id",
                principalTable: "Kitaplar",
                principalColumn: "KitapID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapAlimlari_Uyeler_uye_id",
                table: "KitapAlimlari",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Gorevliler_gorevli_id",
                table: "KitapTalepleri",
                column: "gorevli_id",
                principalTable: "Gorevliler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Kitaplar_kitap_id",
                table: "KitapTalepleri",
                column: "kitap_id",
                principalTable: "Kitaplar",
                principalColumn: "KitapID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Uyeler_uye_id",
                table: "KitapTalepleri",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapAlimlari_Kitaplar_kitap_id",
                table: "KitapAlimlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapAlimlari_Uyeler_uye_id",
                table: "KitapAlimlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Gorevliler_gorevli_id",
                table: "KitapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Kitaplar_kitap_id",
                table: "KitapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapTalepleri_Uyeler_uye_id",
                table: "KitapTalepleri");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri",
                column: "gorevli_id",
                principalTable: "Gorevliler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapAlimlari_Kitaplar_kitap_id",
                table: "KitapAlimlari",
                column: "kitap_id",
                principalTable: "Kitaplar",
                principalColumn: "KitapID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapAlimlari_Uyeler_uye_id",
                table: "KitapAlimlari",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Gorevliler_gorevli_id",
                table: "KitapTalepleri",
                column: "gorevli_id",
                principalTable: "Gorevliler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Kitaplar_kitap_id",
                table: "KitapTalepleri",
                column: "kitap_id",
                principalTable: "Kitaplar",
                principalColumn: "KitapID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitapTalepleri_Uyeler_uye_id",
                table: "KitapTalepleri",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
