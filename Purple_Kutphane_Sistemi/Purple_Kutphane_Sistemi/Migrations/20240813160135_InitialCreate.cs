using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Purple_Kutphane_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HesapTalepleri",
                columns: table => new
                {
                    talep_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<string>(type: "text", nullable: false),
                    durum = table.Column<string>(type: "text", nullable: false),
                    talep_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    son_onaylanma_tarihi = table.Column<string>(type: "text", nullable: false),
                    görevli_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapTalepleri", x => x.talep_id);
                });

            migrationBuilder.CreateTable(
                name: "KitapAlimlari",
                columns: table => new
                {
                    alis_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uye_id = table.Column<int>(type: "integer", nullable: false),
                    kitap_id = table.Column<int>(type: "integer", nullable: false),
                    alis_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    teslim_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapAlimlari", x => x.alis_id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapIsim = table.Column<string>(type: "text", nullable: false),
                    Yazar = table.Column<string>(type: "text", nullable: false),
                    basimYili = table.Column<string>(type: "text", nullable: false),
                    YayınEvi = table.Column<string>(type: "text", nullable: false),
                    Durum = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                });

            migrationBuilder.CreateTable(
                name: "KitapTalepleri",
                columns: table => new
                {
                    talep_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uye_id = table.Column<int>(type: "integer", nullable: false),
                    gorevli_id = table.Column<int>(type: "integer", nullable: false),
                    kitap_id = table.Column<int>(type: "integer", nullable: false),
                    durum = table.Column<string>(type: "text", nullable: false),
                    talep_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    son_onaylanma_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapTalepleri", x => x.talep_id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Kullanici_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Parola = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false),
                    KayıtTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    gorevli_id = table.Column<int>(type: "integer", nullable: true),
                    ceza_durumu = table.Column<bool>(type: "boolean", nullable: true),
                    ceza_puani = table.Column<int>(type: "integer", nullable: true),
                    sys_admin_id = table.Column<int>(type: "integer", nullable: true),
                    uye_id = table.Column<int>(type: "integer", nullable: true),
                    Uye_ceza_durumu = table.Column<bool>(type: "boolean", nullable: true),
                    Uye_ceza_puani = table.Column<int>(type: "integer", nullable: true),
                    yonetici_id = table.Column<int>(type: "integer", nullable: true),
                    Yonetici_ceza_durumu = table.Column<bool>(type: "boolean", nullable: true),
                    Yonetici_ceza_puani = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Kullanici_id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    yazar_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false),
                    KayıtTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.yazar_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesapTalepleri");

            migrationBuilder.DropTable(
                name: "KitapAlimlari");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "KitapTalepleri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
