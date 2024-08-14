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
        public async Task<ActionResult<KitapAlim>> Create(KitapAlim kitapAlim)
        {
            _context.KitapAlimlari.Add(kitapAlim);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Read), new { id = kitapAlim.alis_id }, kitapAlim);
        }

        
        [HttpGet]
        public async Task<ActionResult<List<KitapAlim>>> Read()
        {
            return await _context.KitapAlimlari.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<KitapAlim>> Read(int id)
        {
            var kitapAlim = await _context.KitapAlimlari.FindAsync(id);

            if (kitapAlim == null)
            {
                return NotFound();
            }

            return kitapAlim;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, KitapAlim kitapAlim)
        {
            if (id != kitapAlim.alis_id)
            {
                return BadRequest();
            }

            _context.Entry(kitapAlim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapAlimExists(id))
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

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kitapAlim = await _context.KitapAlimlari.FindAsync(id);
            if (kitapAlim == null)
            {
                return NotFound();
            }

            _context.KitapAlimlari.Remove(kitapAlim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KitapAlimExists(int id)
        {
            return _context.KitapAlimlari.Any(e => e.alis_id == id);
        }
    }
}

