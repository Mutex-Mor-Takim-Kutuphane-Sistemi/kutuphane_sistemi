namespace Purple_Kutphane_Sistemi.Data
{
    public class Mesaj
    {
        public int ID { get; set; }
        public int GonderenID { get; set; }
        public int AliciID { get; set; } 
        public string Icerik { get; set; }
        public DateTime GonderimTarihi { get; set; }
    }
}
