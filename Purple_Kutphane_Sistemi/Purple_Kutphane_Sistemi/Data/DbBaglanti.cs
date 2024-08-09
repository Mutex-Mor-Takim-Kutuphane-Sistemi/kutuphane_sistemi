using Microsoft.EntityFrameworkCore;
using System;


namespace Purple_Kutphane_Sistemi.Data
{
    public class DbBaglanti : DbContext
    {
        public DbBaglanti(DbContextOptions<DbBaglanti> options) : base(options)
        {
        }

        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Gorevli> Gorevliler { get; set; }
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<HesapTalep> HesapTalepleri { get; set; }
        public DbSet<KitapAlim> KitapAlimlari { get; set; }
        public DbSet<KitapTalep> KitapTalepleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SistemYonetici> SistemYoneticileri { get; set; }
    }
}
