using Purple_Kutphane_Sistemi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Purple_Kutphane_Sistemi
{
    public class Kullanici_Islemleri
    {
        private readonly DbBaglanti _context;

        public Kullanici_Islemleri(DbBaglanti context)
        {
            _context = context;
        }

        public async Task<bool> KayitOl(Kullanici yeniKullanici)
        {
            var mevcutKullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == yeniKullanici.Email);

            if (mevcutKullanici != null)
            {
                return false;
            }

            
            yeniKullanici.Parola = HashPassword(yeniKullanici.Parola); // İnanılmaz bir sistem

            yeniKullanici.KayıtTarihi = DateTime.Now;

            _context.Kullanicilar.Add(yeniKullanici);
            await _context.SaveChangesAsync();

            return true;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public async Task<Kullanici> GirisYap(string email, string parola)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == email);

            if (kullanici == null)
            {
                return null;
            }

            var hashliParola = HashPassword(parola);

            if (kullanici.Parola != hashliParola)
            {
                return null;
            }

            else
            return kullanici;
        }

    }
}
