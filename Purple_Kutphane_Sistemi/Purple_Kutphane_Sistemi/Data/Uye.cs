using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Uye : Kullanici
    {
        public int uye_id { get; set; }
        public bool ceza_durumu { get; set; }
        public int ceza_puani { get; set; }

        public ICollection<KitapTalep> KitapTalepleri { get; set; }
        public ICollection<KitapAlim> KitapAlimlari { get; set; }
    }
}
