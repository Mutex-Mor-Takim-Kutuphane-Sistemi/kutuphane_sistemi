using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Purple_Kutphane_Sistemi.Controllers
{

[Route("api/[controller]")]
[ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public KullaniciController(DbBaglanti context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Kullanici> Create(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return Ok(kullanici);
        }

        [HttpGet]
        public ActionResult<List<Kullanici>> Read()
        {
            return _context.Kullanicilar.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Kullanici> Read(int id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return Ok(kullanici);
        }

        [HttpPatch("{id}")]
        public ActionResult<Kullanici> Update(int id, Kullanici kullanici)
        {
            if (id != kullanici.Kullanici_id)
            {
                return BadRequest();
            }

            var existingKullanici = _context.Kullanicilar.Find(id);
            if (existingKullanici == null)
            {
                return NotFound();
            }

            _context.Entry(existingKullanici).CurrentValues.SetValues(kullanici);
            _context.SaveChanges();
            return Ok(existingKullanici);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingKullanici = _context.Kullanicilar.Find(id);
            if (existingKullanici == null)
            {
                return NotFound();
            }

            _context.Kullanicilar.Remove(existingKullanici);
            _context.SaveChanges();
            return Ok();
        }
    }
    }
