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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Uye)
                .WithOne(u => u.Kullanici)
                .HasForeignKey<Uye>(u => u.Kullanici_id);

            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Gorevli)
                .WithOne(g => g.Kullanici)
                .HasForeignKey<Gorevli>(g => g.Kullanici_id);

            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Yonetici)
                .WithOne(y => y.Kullanici)
                .HasForeignKey<Yonetici>(y => y.Kullanici_id);

            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.SistemYoneticisi)
                .WithOne(sy => sy.Kullanici)
                .HasForeignKey<SistemYonetici>(sy => sy.Kullanici_id);
        }
    }
}
