using System.ComponentModel.DataAnnotations;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Kitap
    {
        [Key]
        public int KitapID { get; set; }
        public string KitapIsim { get; set; }
        public string Yazar { get; set; }
        public string basimYili { get; set; }
        public string YayınEvi { get; set; }
        public bool Durum { get; set; }
    }
}
