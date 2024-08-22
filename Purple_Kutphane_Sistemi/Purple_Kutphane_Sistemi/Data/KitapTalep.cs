using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace Purple_Kutphane_Sistemi.Data
{
    public class KitapTalep
    {
        [Key]
        public int talep_id { get; set; }


        [ForeignKey("Uye")]
        public int uye_id { get; set; }
        public Uye uye { get; set; }


        [ForeignKey("Gorevli")]
        public int gorevli_id { get; set; }
        public Gorevli Gorevli { get; set; }


        [ForeignKey("Kitap")]
        public int kitap_id { get; set; }
        public Kitap Kitap { get; set; }


        public string durum { get; set; }
        public DateTime talep_tarihi { get; set; }
        public DateTime son_onaylanma_tarihi { get; set; }

    }
}
