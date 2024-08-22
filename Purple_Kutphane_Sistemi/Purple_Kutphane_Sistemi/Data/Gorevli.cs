using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Gorevli : Kullanici
    {
        public int gorevli_id { get; set; }
        public bool ceza_durumu { get; set; }
        public int ceza_puani { get; set; }

        public ICollection<HesapTalep> HesapTalepleri { get; set; }
        public ICollection<KitapTalep> KitapTalepleri { get; set; }
    }
}
