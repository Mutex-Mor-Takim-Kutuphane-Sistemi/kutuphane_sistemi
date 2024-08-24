using Purple_Kutphane_Sistemi.Data;
using System;

namespace Purple_Kutphane_Sistemi
{
    public class Yazar_Islemleri
    {
        public Kitap KitapOnayIste(Kitap kitap)
        {
            if (kitap != null)
                return kitap;
            else
                return null;
        }

        private readonly DbBaglanti _context;

        public Yazar_Islemleri(DbBaglanti context)
        {
            _context = context;
        }

        public async Task<bool> MesajGonder(int yazarID, int yoneticiID, string mesajIcerigi)
        {
         
            if (string.IsNullOrWhiteSpace(mesajIcerigi))
            {
                return false;
            }

            
            var mesaj = new Mesaj
            {
                GonderenID = yazarID,
                AliciID = yoneticiID,
                Icerik = mesajIcerigi,
                GonderimTarihi = DateTime.Now
            };

            
            _context.Mesajlar.Add(mesaj);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
