using Microsoft.AspNetCore.Mvc;
using Purple_Kutphane_Sistemi.Data;

namespace Purple_Kutphane_Sistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YoneticiController : ControllerBase
    {
        private readonly DbBaglanti _context;

        public YoneticiController(DbBaglanti context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Yonetici> Create(Yonetici yonetici)
        {
            _context.Yoneticiler.Add(yonetici);
            _context.SaveChanges();
            return Ok(yonetici);
        }

        [HttpGet]
        public ActionResult<List<Yonetici>> Read()
        {
            return _context.Yoneticiler.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Yonetici> Read(int id)
        {
            var yonetici = _context.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return NotFound();
            }
            return Ok(yonetici);
        }

        [HttpPatch("{id}")]
        public ActionResult<Yonetici> Update(int id, Yonetici yonetici)
        {
            if (id != yonetici.yonetici_id)
            {
                return BadRequest();
            }

            var existingYonetici = _context.Yoneticiler.Find(id);
            if (existingYonetici == null)
            {
                return NotFound();
            }

            _context.Entry(existingYonetici).CurrentValues.SetValues(yonetici);
            _context.SaveChanges();
            return Ok(existingYonetici);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingYonetici = _context.Yoneticiler.Find(id);
            if (existingYonetici == null)
            {
                return NotFound();
            }

            _context.Yoneticiler.Remove(existingYonetici);
            _context.SaveChanges();
            return Ok();
        }
    }
}
