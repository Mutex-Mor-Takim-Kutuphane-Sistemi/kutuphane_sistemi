﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Purple_Kutphane_Sistemi.Data
{
    public class Yonetici : Kullanici
    {
        public int yonetici_id { get; set; }
        public bool ceza_durumu { get; set; }
        public int ceza_puani { get; set; }
    }
}
