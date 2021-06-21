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
    public class BestellungController : ControllerBase
    {
        private readonly DataContext _context;

        public BestellungController(DataContext context)
        {
            _context = context;
        }

        // PUT: api/Bestellung/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellung(int id, Bestellung Bestellung)
        {
            if (id != Bestellung.Id)
            {
                return BadRequest();
            }

            _context.Entry(Bestellung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellungExists(id))
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

        // POST: api/Bestellung
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bestellung>> PostBestellung(Bestellung Bestellung)
        {
            _context.Bestellung.Add(Bestellung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBestellung", new { id = Bestellung.Id }, Bestellung);
        }

        // DELETE: api/Bestellung/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestellung(int id)
        {
            var Bestellung = await _context.Bestellung.FindAsync(id);
            if (Bestellung == null)
            {
                return NotFound();
            }

            _context.Bestellung.Remove(Bestellung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BestellungExists(int id)
        {
            return _context.Bestellung.Any(e => e.Id == id);
        }
    }
}
