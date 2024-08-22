using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;

namespace Purple_Kutphane_Sistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SistemYoneticiController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public SistemYoneticiController(DbBaglanti context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<SistemYonetici> Create(SistemYonetici sistemYonetici)
        {
            _context.SistemYoneticileri.Add(sistemYonetici);
            _context.SaveChanges();
            return Ok(sistemYonetici);
        }

        [HttpGet]
        public ActionResult<List<SistemYonetici>> Read()
        {
            return _context.SistemYoneticileri.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<SistemYonetici> Read(int id)
        {
            var sistemYonetici = _context.SistemYoneticileri.Find(id);
            if (sistemYonetici == null)
            {
                return NotFound();
            }
            return Ok(sistemYonetici);
        }

        [HttpPatch("{id}")]
        public ActionResult<SistemYonetici> Update(int id, SistemYonetici sistemYonetici)
        {
            if (id != sistemYonetici.Kullanici_id)  // SistemYonetici sınıfı Kullanici'den türediği için Kullanici_id'yi kullanıyoruz
            {
                return BadRequest();
            }

            var existingSistemYonetici = _context.SistemYoneticileri.Find(id);
            if (existingSistemYonetici == null)
            {
                return NotFound();
            }

            _context.Entry(existingSistemYonetici).CurrentValues.SetValues(sistemYonetici);
            _context.SaveChanges();
            return Ok(existingSistemYonetici);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingSistemYonetici = _context.SistemYoneticileri.Find(id);
            if (existingSistemYonetici == null)
            {
                return NotFound();
            }

            _context.SistemYoneticileri.Remove(existingSistemYonetici);
            _context.SaveChanges();
            return Ok();
        }
    }
}
