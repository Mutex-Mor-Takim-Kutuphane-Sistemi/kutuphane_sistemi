using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;

namespace Purple_Kutphane_Sistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YazarController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public YazarController(DbBaglanti context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Yazar> Create(Yazar yazar)
        {
            _context.Yazarlar.Add(yazar);
            _context.SaveChanges();
            return Ok(yazar);
        }

        [HttpGet]
        public ActionResult<List<Yazar>> Read()
        {
            return _context.Yazarlar.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Yazar> Read(int id)
        {
            var yazar = _context.Yazarlar.Find(id);
            if (yazar == null)
            {
                return NotFound();
            }
            return Ok(yazar);
        }

        [HttpPatch("{id}")]
        public ActionResult<Yazar> Update(int id, Yazar yazar)
        {
            if (id != yazar.yazar_id)
            {
                return BadRequest();
            }

            var existingYazar = _context.Yazarlar.Find(id);
            if (existingYazar == null)
            {
                return NotFound();
            }

            _context.Entry(existingYazar).CurrentValues.SetValues(yazar);
            _context.SaveChanges();
            return Ok(existingYazar);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingYazar = _context.Yazarlar.Find(id);
            if (existingYazar == null)
            {
                return NotFound();
            }

            _context.Yazarlar.Remove(existingYazar);
            _context.SaveChanges();
            return Ok();
        }
    }
}
