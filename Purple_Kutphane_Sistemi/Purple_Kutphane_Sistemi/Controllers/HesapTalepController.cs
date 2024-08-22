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

        [HttpPost]
        public ActionResult<HesapTalep> Create(HesapTalep hesapTalep)
        {
            _context.HesapTalepleri.Add(hesapTalep);
            _context.SaveChanges();
            return Ok(hesapTalep);
        }

        [HttpGet]
        public ActionResult<List<HesapTalep>> Read()
        {
            return _context.HesapTalepleri.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<HesapTalep> Read(int id)
        {
            var hesapTalep = _context.HesapTalepleri.Find(id);
            if (hesapTalep == null)
            {
                return NotFound();
            }
            return Ok(hesapTalep);
        }

        [HttpPatch("{id}")]
        public ActionResult<HesapTalep> Update(int id, HesapTalep hesapTalep)
        {
            if (id != hesapTalep.talep_id)
            {
                return BadRequest();
            }

            var existingHesapTalep = _context.HesapTalepleri.Find(id);
            if (existingHesapTalep == null)
            {
                return NotFound();
            }

            _context.Entry(existingHesapTalep).CurrentValues.SetValues(hesapTalep);
            _context.SaveChanges();
            return Ok(existingHesapTalep);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingHesapTalep = _context.HesapTalepleri.Find(id);
            if (existingHesapTalep == null)
            {
                return NotFound();
            }

            _context.HesapTalepleri.Remove(existingHesapTalep);
            _context.SaveChanges();
            return Ok();
        }
    }
}


