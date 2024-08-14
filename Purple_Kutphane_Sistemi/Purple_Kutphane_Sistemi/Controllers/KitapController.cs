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

        // POST: api/Kitap
        [HttpPost]
        public async Task<ActionResult<Kitap>> Create(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Read), new { id = kitap.KitapID }, kitap);
        }

        // GET: api/Kitap
        [HttpGet]
        public async Task<ActionResult<List<Kitap>>> Read()
        {
            return await _context.Kitaplar.ToListAsync();
        }

        // GET: api/Kitap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kitap>> Read(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);

            if (kitap == null)
            {
                return NotFound();
            }

            return kitap;
        }

        // PUT: api/Kitap/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Kitap kitap)
        {
            if (id != kitap.KitapID)
            {
                return BadRequest();
            }

            _context.Entry(kitap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapExists(id))
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

        // DELETE: api/Kitap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.KitapID == id);
        }
    }
}




