using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class HesapTalep
    {
        [Key]
        public int talep_id { get; set; }


        [ForeignKey("Uye")]
        public int uye_id { get; set; }
        public Uye uye { get; set; }


        [ForeignKey("Gorevli")]
        public int gorevli_id { get; set; }
        public Gorevli Gorevli { get; set; }


        public string durum { get; set; }
        public DateTime talep_tarihi { get; set; }
        public string son_onaylanma_tarihi { get; set; }
    }
}
