namespace Purple_Kutphane_Sistemi.Data
{
    public class HesapTalep
    {
        public int talep_id { get; set; }
        public string kullanici_id { get; set; }
        public string durum { get; set; }
        public DateTime talep_tarihi { get; set; }
        public string son_onaylanma_tarihi { get; set; }
        public int görevli_id { get; set; }
    }
}
