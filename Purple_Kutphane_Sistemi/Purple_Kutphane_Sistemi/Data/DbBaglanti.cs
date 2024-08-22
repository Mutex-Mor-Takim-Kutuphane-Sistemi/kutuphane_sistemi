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
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Kullanici>()
                .ToTable("Kullanicilar");

            modelBuilder.Entity<Uye>()
                .ToTable("Uyeler")
                .HasBaseType<Kullanici>();

            modelBuilder.Entity<Gorevli>()
                .ToTable("Gorevliler")
                .HasBaseType<Kullanici>();

            modelBuilder.Entity<Yonetici>()
                .ToTable("Yonetici")
                .HasBaseType<Kullanici>();

            modelBuilder.Entity<SistemYonetici>()
                .ToTable("SistemYoneticileri")
                .HasBaseType<Kullanici>();

            
            modelBuilder.Entity<KitapAlim>()
                .HasOne(ka => ka.uye)
                .WithMany(u => u.KitapAlimlari)
                .HasForeignKey(ka => ka.uye_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KitapAlim>()
                .HasOne(ka => ka.Kitap)
                .WithMany(k => k.KitapAlimlari)
                .HasForeignKey(ka => ka.kitap_id)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<HesapTalep>()
                .HasOne(ht => ht.uye)
                .WithMany(u => u.HesapTalepleri)
                .HasForeignKey(ht => ht.uye_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HesapTalep>()
                .HasOne(ht => ht.Gorevli)
                .WithMany(g => g.HesapTalepleri)
                .HasForeignKey(ht => ht.gorevli_id)
                .OnDelete(DeleteBehavior.SetNull);

            
            modelBuilder.Entity<KitapTalep>()
                .HasOne(kt => kt.uye)
                .WithMany(u => u.KitapTalepleri)
                .HasForeignKey(kt => kt.uye_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KitapTalep>()
                .HasOne(kt => kt.Gorevli)
                .WithMany(g => g.KitapTalepleri)
                .HasForeignKey(kt => kt.gorevli_id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<KitapTalep>()
                .HasOne(kt => kt.Kitap)
                .WithMany(k => k.KitapTalepleri)
                .HasForeignKey(kt => kt.kitap_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
