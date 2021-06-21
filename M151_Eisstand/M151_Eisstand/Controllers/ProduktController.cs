using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M151_Eisstand.Data;
using M151_Eisstand.Modell;

namespace M151_Eisstand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProduktsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Produkts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkt>>> GetProdukt()
        {
            return await _context.Produkt.ToListAsync();
        }

        // GET: api/Produkts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkt>> GetProdukt(int id)
        {
            var Produkt = await _context.Produkt.FindAsync(id);

            if (Produkt == null)
            {
                return NotFound();
            }

            return Produkt;
        }


        // POST: api/Produkts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produkt>> PostProdukt(Produkt Produkt)
        {
            _context.Produkt.Add(Produkt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdukt", new { id = Produkt.Id }, Produkt);
        }

        // DELETE: api/Produkts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            var Produkt = await _context.Produkt.FindAsync(id);
            if (Produkt == null)
            {
                return NotFound();
            }

            _context.Produkt.Remove(Produkt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkt.Any(e => e.Id == id);
        }
    }
}
