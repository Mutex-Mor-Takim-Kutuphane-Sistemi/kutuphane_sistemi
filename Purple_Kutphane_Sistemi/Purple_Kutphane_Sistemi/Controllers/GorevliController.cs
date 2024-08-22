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
        public ActionResult<Gorevli> Create(Gorevli gorevli)
        {
            _context.Gorevliler.Add(gorevli);
            _context.SaveChanges();
            return Ok(gorevli);
        }

        [HttpGet]
        public ActionResult<List<Gorevli>> Read()
        {
            return _context.Gorevliler.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Gorevli> Read(int id)
        {
            var gorevli = _context.Gorevliler.Find(id);
            if (gorevli == null)
            {
                return NotFound();
            }
            return Ok(gorevli);
        }

        [HttpPatch("{id}")]
        public ActionResult<Gorevli> Update(int id, Gorevli gorevli)
        {
            if (id != gorevli.gorevli_id)
            {
                return BadRequest();
            }

            var existingGorevli = _context.Gorevliler.Find(id);
            if (existingGorevli == null)
            {
                return NotFound();
            }

            _context.Entry(existingGorevli).CurrentValues.SetValues(gorevli);
            _context.SaveChanges();
            return Ok(existingGorevli);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingGorevli = _context.Gorevliler.Find(id);
            if (existingGorevli == null)
            {
                return NotFound();
            }

            _context.Gorevliler.Remove(existingGorevli);
            _context.SaveChanges();
            return Ok();
        }
    }
}
