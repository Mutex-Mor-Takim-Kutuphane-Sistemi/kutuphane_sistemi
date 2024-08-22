using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;

namespace Purple_Kutphane_Sistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UyeController : ControllerBase
    { 
        private readonly DbBaglanti _context;

        public UyeController(DbBaglanti context)
        {
            _context = context;
        }
    
        [HttpPost]
        public ActionResult<Uye> Create(Uye uye)
        {
            _context.Uyeler.Add(uye);
            _context.SaveChanges();
            return Ok(uye);
        }

        [HttpGet]
        public ActionResult<List<Uye>> Read()
        {
            return _context.Uyeler.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Uye> Read(int id)
        {
            var uye = _context.Uyeler.Find(id);
            if (uye == null)
            {
                return NotFound();
            }
            return Ok(uye);
        }

        [HttpPatch("{id}")]
        public ActionResult<Uye> Update(int id, Uye uye)
        {
            if (id != uye.Kullanici_id)  // Uye sınıfı Kullanici'den türediği için Kullanici_id'yi kullanıyoruz
            {
                return BadRequest();
            }

            var existingUye = _context.Uyeler.Find(id);
            if (existingUye == null)
            {
                return NotFound();
            }

            _context.Entry(existingUye).CurrentValues.SetValues(uye);
            _context.SaveChanges();
            return Ok(existingUye);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUye = _context.Uyeler.Find(id);
            if (existingUye == null)
            {
                return NotFound();
            }

            _context.Uyeler.Remove(existingUye);
            _context.SaveChanges();
            return Ok();
        }
    }
}
