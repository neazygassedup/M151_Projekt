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
    public class KugelnController : ControllerBase
    {
        private readonly DataContext _context;

        public KugelnController(DataContext context)
        {
            _context = context;
        }

        // PUT: api/Kugeln/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKugeln(int id, Kugeln Kugeln)
        {
            if (id != Kugeln.Id)
            {
                return BadRequest();
            }

            _context.Entry(Kugeln).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KugelnExists(id))
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

        // POST: api/Kugeln
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kugeln>> PostKugeln(Kugeln Kugeln)
        {
            _context.Kugeln.Add(Kugeln);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKugeln", new { id = Kugeln.Id }, Kugeln);
        }
    }
}
