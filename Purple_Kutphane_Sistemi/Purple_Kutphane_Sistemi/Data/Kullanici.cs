using System.ComponentModel.DataAnnotations;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Kullanici
    {
        [Key]
        public int Kullanici_id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Rol { get; set; }
        public DateTime KayıtTarihi { get; set; }


        public ICollection<Uye> Uyeler { get; set; }
        public ICollection<Gorevli> Gorevliler { get; set; }
        public ICollection<Yonetici> Yoneticiler { get; set; }
        public ICollection<SistemYonetici> SistemYoneticileri { get; set; }
        public ICollection<HesapTalep> HesapTalepleri { get; set; }



    }
}
