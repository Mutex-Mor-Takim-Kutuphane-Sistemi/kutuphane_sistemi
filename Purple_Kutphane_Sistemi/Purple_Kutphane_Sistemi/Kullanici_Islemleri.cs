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

        public async Task<bool> KayitOl(Kullanici yeniKullanici, string anneKizlikSoyad)
        {
            var mevcutKullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == yeniKullanici.Email);

            if (mevcutKullanici != null)
            {
                return false;
            }

            
            yeniKullanici.Parola = HashPassword(yeniKullanici.Parola); // İnanılmaz bir sistem

            yeniKullanici.Annesoyad = anneKizlikSoyad;

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

        public async Task<bool> SifreDegistir(int kullaniciId, string mevcutParola, string yeniParola)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Kullanici_id == kullaniciId);

            if (kullanici == null)
            {
                return false;
            }

            
            var hashliMevcutParola = HashPassword(mevcutParola);
            if (kullanici.Parola != hashliMevcutParola)
            {
                return false;
            }

            
            kullanici.Parola = HashPassword(yeniParola);

            
            _context.Kullanicilar.Update(kullanici);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SifremiUnuttum(int kullaniciID, string anneKizlikSoyad, string yeniSifre)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Kullanici_id == kullaniciID);

            if(kullanici == null)
                return false;

            if (anneKizlikSoyad != kullanici.Annesoyad) //if (!string.Equals(anneKizlikSoyad, kullanici.Annesoyad, StringComparison.OrdinalIgnoreCase)) return false;
                return false;

            


            kullanici.Parola = HashPassword (yeniSifre);

            _context.Kullanicilar .Update(kullanici);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
