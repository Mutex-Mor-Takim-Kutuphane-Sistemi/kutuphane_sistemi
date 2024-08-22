using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purple_Kutphane_Sistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public KitapController(DbBaglanti context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Kitap> Create(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return Ok(kitap);
        }

        [HttpGet]
        public ActionResult<List<Kitap>> Read()
        {
            return _context.Kitaplar.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Kitap> Read(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return Ok(kitap);
        }

        [HttpPatch("{id}")]
        public ActionResult<Kitap> Update(int id, Kitap kitap)
        {
            if (id != kitap.KitapID)
            {
                return BadRequest();
            }

            var existingKitap = _context.Kitaplar.Find(id);
            if (existingKitap == null)
            {
                return NotFound();
            }

            _context.Entry(existingKitap).CurrentValues.SetValues(kitap);
            _context.SaveChanges();
            return Ok(existingKitap);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingKitap = _context.Kitaplar.Find(id);
            if (existingKitap == null)
            {
                return NotFound();
            }

            _context.Kitaplar.Remove(existingKitap);
            _context.SaveChanges();
            return Ok();
        }
    }
}




