using System.ComponentModel.DataAnnotations;

namespace Purple_Kutphane_Sistemi.Data
{
    public class KitapAlim
    {
        [Key] 
        public int alis_id { get; set; }
        public int uye_id { get; set; }
        public int kitap_id { get; set; }
        public DateTime alis_tarihi { get; set; }
        public DateTime teslim_tarihi { get; set; }
    }
}
