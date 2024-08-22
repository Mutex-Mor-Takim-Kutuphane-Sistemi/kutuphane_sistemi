using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class KitapAlim
    {
        [Key] 
        public int alis_id { get; set; }



        [ForeignKey("Uye")]
        public int uye_id { get; set; }
        public Uye uye { get; set; }



        [ForeignKey("Kitap")]
        public int kitap_id { get; set; }
        public Kitap Kitap { get; set; }


        public DateTime alis_tarihi { get; set; }
        public DateTime teslim_tarihi { get; set; }
    }
}
