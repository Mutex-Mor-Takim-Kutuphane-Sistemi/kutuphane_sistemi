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
    public class GorevliController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public GorevliController(DbBaglanti context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Gorevli>> Create(Gorevli gorevli)
        {
            _context.Gorevliler.Add(gorevli);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Read), new { id = gorevli.gorevli_id }, gorevli);
        }

        // GET: api/Gorevli
        [HttpGet]
        public async Task<ActionResult<List<Gorevli>>> Read()
        {
            return await _context.Gorevliler.ToListAsync();
        }

        // GET: api/Gorevli/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gorevli>> Read(int id)
        {
            var gorevli = await _context.Gorevliler.FindAsync(id);

            if (gorevli == null)
            {
                return NotFound();
            }

            return gorevli;
        }

        // PUT: api/Gorevli/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Gorevli gorevli)
        {
            if (id != gorevli.gorevli_id)
            {
                return BadRequest();
            }

            _context.Entry(gorevli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GorevliExists(id))
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

        // DELETE: api/Gorevli/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gorevli = await _context.Gorevliler.FindAsync(id);
            if (gorevli == null)
            {
                return NotFound();
            }

            _context.Gorevliler.Remove(gorevli);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GorevliExists(int id)
        {
            return _context.Gorevliler.Any(e => e.gorevli_id == id);
        }
    }
}
