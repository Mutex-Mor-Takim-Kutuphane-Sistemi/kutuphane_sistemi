using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Purple_Kutphane_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class addReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullaniciTempId",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Uye_ceza_durumu",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Uye_ceza_puani",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Yonetici_ceza_durumu",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Yonetici_ceza_puani",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "ceza_durumu",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "ceza_puani",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "gorevli_id",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "sys_admin_id",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "uye_id",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "yonetici_id",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "kullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.RenameColumn(
                name: "görevli_id",
                table: "HesapTalepleri",
                newName: "uye_id");

            migrationBuilder.AddColumn<int>(
                name: "SistemYoneticiKullanici_id",
                table: "HesapTalepleri",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YoneticiKullanici_id",
                table: "HesapTalepleri",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gorevli_id",
                table: "HesapTalepleri",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gorevliler",
                columns: table => new
                {
                    Kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    gorevli_id = table.Column<int>(type: "integer", nullable: false),
                    ceza_durumu = table.Column<bool>(type: "boolean", nullable: false),
                    ceza_puani = table.Column<int>(type: "integer", nullable: false),
                    Kullanici_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevliler", x => x.Kullanici_id);
                    table.ForeignKey(
                        name: "FK_Gorevliler_Kullanicilar_Kullanici_id",
                        column: x => x.Kullanici_id,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gorevliler_Kullanicilar_Kullanici_id1",
                        column: x => x.Kullanici_id1,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id");
                });

            migrationBuilder.CreateTable(
                name: "SistemYoneticileri",
                columns: table => new
                {
                    Kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    sys_admin_id = table.Column<int>(type: "integer", nullable: false),
                    Kullanici_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemYoneticileri", x => x.Kullanici_id);
                    table.ForeignKey(
                        name: "FK_SistemYoneticileri_Kullanicilar_Kullanici_id",
                        column: x => x.Kullanici_id,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemYoneticileri_Kullanicilar_Kullanici_id1",
                        column: x => x.Kullanici_id1,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id");
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    uye_id = table.Column<int>(type: "integer", nullable: false),
                    ceza_durumu = table.Column<bool>(type: "boolean", nullable: false),
                    ceza_puani = table.Column<int>(type: "integer", nullable: false),
                    Kullanici_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Kullanici_id);
                    table.ForeignKey(
                        name: "FK_Uyeler_Kullanicilar_Kullanici_id",
                        column: x => x.Kullanici_id,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uyeler_Kullanicilar_Kullanici_id1",
                        column: x => x.Kullanici_id1,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id");
                });

            migrationBuilder.CreateTable(
                name: "Yonetici",
                columns: table => new
                {
                    Kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    yonetici_id = table.Column<int>(type: "integer", nullable: false),
                    ceza_durumu = table.Column<bool>(type: "boolean", nullable: false),
                    ceza_puani = table.Column<int>(type: "integer", nullable: false),
                    Kullanici_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetici", x => x.Kullanici_id);
                    table.ForeignKey(
                        name: "FK_Yonetici_Kullanicilar_Kullanici_id",
                        column: x => x.Kullanici_id,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yonetici_Kullanicilar_Kullanici_id1",
                        column: x => x.Kullanici_id1,
                        principalTable: "Kullanicilar",
                        principalColumn: "Kullanici_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapTalepleri_gorevli_id",
                table: "KitapTalepleri",
                column: "gorevli_id");

            migrationBuilder.CreateIndex(
                name: "IX_KitapTalepleri_kitap_id",
                table: "KitapTalepleri",
                column: "kitap_id");

            migrationBuilder.CreateIndex(
                name: "IX_KitapTalepleri_uye_id",
                table: "KitapTalepleri",
                column: "uye_id");

            migrationBuilder.CreateIndex(
                name: "IX_KitapAlimlari_kitap_id",
                table: "KitapAlimlari",
                column: "kitap_id");

            migrationBuilder.CreateIndex(
                name: "IX_KitapAlimlari_uye_id",
                table: "KitapAlimlari",
                column: "uye_id");

            migrationBuilder.CreateIndex(
                name: "IX_HesapTalepleri_gorevli_id",
                table: "HesapTalepleri",
                column: "gorevli_id");

            migrationBuilder.CreateIndex(
                name: "IX_HesapTalepleri_SistemYoneticiKullanici_id",
                table: "HesapTalepleri",
                column: "SistemYoneticiKullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_HesapTalepleri_uye_id",
                table: "HesapTalepleri",
                column: "uye_id");

            migrationBuilder.CreateIndex(
                name: "IX_HesapTalepleri_YoneticiKullanici_id",
                table: "HesapTalepleri",
                column: "YoneticiKullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevliler_Kullanici_id1",
                table: "Gorevliler",
                column: "Kullanici_id1");

            migrationBuilder.CreateIndex(
                name: "IX_SistemYoneticileri_Kullanici_id1",
                table: "SistemYoneticileri",
                column: "Kullanici_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_Kullanici_id1",
                table: "Uyeler",
                column: "Kullanici_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Yonetici_Kullanici_id1",
                table: "Yonetici",
                column: "Kullanici_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri",
                column: "gorevli_id",
                principalTable: "Gorevliler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_SistemYoneticileri_SistemYoneticiKullanici_id",
                table: "HesapTalepleri",
                column: "SistemYoneticiKullanici_id",
                principalTable: "SistemYoneticileri",
                principalColumn: "Kullanici_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri",
                column: "uye_id",
                principalTable: "Uyeler",
                principalColumn: "Kullanici_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTalepleri_Yonetici_YoneticiKullanici_id",
                table: "HesapTalepleri",
                column: "YoneticiKullanici_id",
                principalTable: "Yonetici",
                principalColumn: "Kullanici_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Gorevliler_gorevli_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_SistemYoneticileri_SistemYoneticiKullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Uyeler_uye_id",
                table: "HesapTalepleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapTalepleri_Yonetici_YoneticiKullanici_id",
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

            migrationBuilder.DropTable(
                name: "Gorevliler");

            migrationBuilder.DropTable(
                name: "SistemYoneticileri");

            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Yonetici");

            migrationBuilder.DropIndex(
                name: "IX_KitapTalepleri_gorevli_id",
                table: "KitapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_KitapTalepleri_kitap_id",
                table: "KitapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_KitapTalepleri_uye_id",
                table: "KitapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_KitapAlimlari_kitap_id",
                table: "KitapAlimlari");

            migrationBuilder.DropIndex(
                name: "IX_KitapAlimlari_uye_id",
                table: "KitapAlimlari");

            migrationBuilder.DropIndex(
                name: "IX_HesapTalepleri_gorevli_id",
                table: "HesapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_HesapTalepleri_SistemYoneticiKullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_HesapTalepleri_uye_id",
                table: "HesapTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_HesapTalepleri_YoneticiKullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.DropColumn(
                name: "SistemYoneticiKullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.DropColumn(
                name: "YoneticiKullanici_id",
                table: "HesapTalepleri");

            migrationBuilder.DropColumn(
                name: "gorevli_id",
                table: "HesapTalepleri");

            migrationBuilder.RenameColumn(
                name: "uye_id",
                table: "HesapTalepleri",
                newName: "görevli_id");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Kullanicilar",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KullaniciTempId",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Uye_ceza_durumu",
                table: "Kullanicilar",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uye_ceza_puani",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Yonetici_ceza_durumu",
                table: "Kullanicilar",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Yonetici_ceza_puani",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ceza_durumu",
                table: "Kullanicilar",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ceza_puani",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gorevli_id",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sys_admin_id",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "uye_id",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yonetici_id",
                table: "Kullanicilar",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kullanici_id",
                table: "HesapTalepleri",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
