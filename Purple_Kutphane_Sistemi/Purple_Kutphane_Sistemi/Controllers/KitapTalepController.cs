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
    public class KitapTalepController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public KitapTalepController(DbBaglanti context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<KitapTalep> Create(KitapTalep kitapTalep)
        {
            _context.KitapTalepleri.Add(kitapTalep);
            _context.SaveChanges();
            return Ok(kitapTalep);
        }

        [HttpGet]
        public ActionResult<List<KitapTalep>> Read()
        {
            return _context.KitapTalepleri.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<KitapTalep> Read(int id)
        {
            var kitapTalep = _context.KitapTalepleri.Find(id);
            if (kitapTalep == null)
            {
                return NotFound();
            }
            return Ok(kitapTalep);
        }

        [HttpPatch("{id}")]
        public ActionResult<KitapTalep> Update(int id, KitapTalep kitapTalep)
        {
            if (id != kitapTalep.talep_id)
            {
                return BadRequest();
            }

            var existingKitapTalep = _context.KitapTalepleri.Find(id);
            if (existingKitapTalep == null)
            {
                return NotFound();
            }

            _context.Entry(existingKitapTalep).CurrentValues.SetValues(kitapTalep);
            _context.SaveChanges();
            return Ok(existingKitapTalep);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingKitapTalep = _context.KitapTalepleri.Find(id);
            if (existingKitapTalep == null)
            {
                return NotFound();
            }

            _context.KitapTalepleri.Remove(existingKitapTalep);
            _context.SaveChanges();
            return Ok();
        }
    }
}
