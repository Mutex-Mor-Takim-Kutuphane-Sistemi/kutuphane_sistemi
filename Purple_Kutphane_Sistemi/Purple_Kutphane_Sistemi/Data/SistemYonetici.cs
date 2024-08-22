using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class SistemYonetici : Kullanici
    {
        public int sys_admin_id { get; set; }
    }
}
