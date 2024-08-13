using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace Purple_Kutphane_Sistemi.Data
{
    public class KitapTalep
    {
        [Key]
        public int talep_id { get; set; }
        public int uye_id { get; set; }
        public int gorevli_id { get; set; }
        public int kitap_id { get; set; }
        public string durum { get; set; }
        public DateTime talep_tarihi { get; set; }
        public DateTime son_onaylanma_tarihi { get; set; }

    }
}
