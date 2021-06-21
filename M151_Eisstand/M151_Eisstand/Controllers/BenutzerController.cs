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
    public class BenutzersController : ControllerBase
    {
        private readonly DataContext _context;

        public BenutzersController(DataContext context)
        {
            _context = context;
        }

        // PUT: api/Benutzers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenutzer(int id, Benutzer benutzer)
        {
            if (id != benutzer.Id)
            {
                return BadRequest();
            }

            _context.Entry(benutzer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenutzerExists(id))
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

        // POST: api/Benutzers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Benutzer>> PostBenutzer(Benutzer benutzer)
        {
            _context.Benutzer.Add(benutzer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenutzer", new { id = benutzer.Id }, benutzer);
        }

        private bool BenutzerExists(int id)
        {
            return _context.Benutzer.Any(e => e.Id == id);
        }
    }
}
