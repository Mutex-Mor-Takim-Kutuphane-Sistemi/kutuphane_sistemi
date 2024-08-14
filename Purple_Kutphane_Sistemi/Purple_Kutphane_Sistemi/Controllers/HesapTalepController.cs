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
    public class HesapTalepController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public HesapTalepController(DbBaglanti context)
        {
            _context = context;
        }

        // POST: api/HesapTalep
        [HttpPost]
        public async Task<ActionResult<HesapTalep>> Create(HesapTalep hesapTalep)
        {
            _context.HesapTalepleri.Add(hesapTalep);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Read), new { id = hesapTalep.talep_id }, hesapTalep);
        }

        // GET: api/HesapTalep
        [HttpGet]
        public async Task<ActionResult<List<HesapTalep>>> Read()
        {
            return await _context.HesapTalepleri.ToListAsync();
        }

        // GET: api/HesapTalep/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HesapTalep>> Read(int id)
        {
            var hesapTalep = await _context.HesapTalepleri.FindAsync(id);

            if (hesapTalep == null)
            {
                return NotFound();
            }

            return hesapTalep;
        }

        // PATCH: api/HesapTalep/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, HesapTalep hesapTalep)
        {
            if (id != hesapTalep.talep_id)
            {
                return BadRequest();
            }

            _context.Entry(hesapTalep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HesapTalepExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/HesapTalep/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hesapTalep = await _context.HesapTalepleri.FindAsync(id);
            if (hesapTalep == null)
            {
                return NotFound();
            }

            _context.HesapTalepleri.Remove(hesapTalep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HesapTalepExists(int id)
        {
            return _context.HesapTalepleri.Any(e => e.talep_id == id);
        }
    }
}


