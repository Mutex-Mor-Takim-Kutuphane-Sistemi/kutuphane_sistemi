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
    public class KitapAlimController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public KitapAlimController(DbBaglanti context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult<KitapAlim> Create(KitapAlim kitapAlim)
        {
            _context.KitapAlimlari.Add(kitapAlim);
            _context.SaveChanges();
            return Ok(kitapAlim);
        }

        [HttpGet]
        public ActionResult<List<KitapAlim>> Read()
        {
            return _context.KitapAlimlari.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<KitapAlim> Read(int id)
        {
            var kitapAlim = _context.KitapAlimlari.Find(id);
            if (kitapAlim == null)
            {
                return NotFound();
            }
            return Ok(kitapAlim);
        }

        [HttpPatch("{id}")]
        public ActionResult<KitapAlim> Update(int id, KitapAlim kitapAlim)
        {
            if (id != kitapAlim.alis_id)
            {
                return BadRequest();
            }

            var existingKitapAlim = _context.KitapAlimlari.Find(id);
            if (existingKitapAlim == null)
            {
                return NotFound();
            }

            _context.Entry(existingKitapAlim).CurrentValues.SetValues(kitapAlim);
            _context.SaveChanges();
            return Ok(existingKitapAlim);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingKitapAlim = _context.KitapAlimlari.Find(id);
            if (existingKitapAlim == null)
            {
                return NotFound();
            }

            _context.KitapAlimlari.Remove(existingKitapAlim);
            _context.SaveChanges();
            return Ok();
        }
    }
}

