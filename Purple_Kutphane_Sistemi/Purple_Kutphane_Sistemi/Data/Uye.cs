using System.ComponentModel.DataAnnotations;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Uye : Kullanici
    {
        public int uye_id { get; set; }
        public bool ceza_durumu { get; set; }
        public int ceza_puani { get; set; }

    }
}
