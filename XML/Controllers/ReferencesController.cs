using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XML.Data;
using XML.Domain;

namespace XML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly XMLContext _context;

        public ReferencesController(XMLContext context)
        {
            _context = context;
        }

        // GET: api/References
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reference>>> GetReference()
        {
          if (_context.Reference == null)
          {
              return NotFound();
          }
            return await _context.Reference.ToListAsync();
        }

        // GET: api/References/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reference>> GetReference(int id)
        {
          if (_context.Reference == null)
          {
              return NotFound();
          }
            var reference = await _context.Reference.FindAsync(id);

            if (reference == null)
            {
                return NotFound();
            }

            return reference;
        }

        // PUT: api/References/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReference(int id, Reference reference)
        {
            if (id != reference.Id)
            {
                return BadRequest();
            }

            _context.Entry(reference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenceExists(id))
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

        // POST: api/References
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reference>> PostReference(Reference reference)
        {
          if (_context.Reference == null)
          {
              return Problem("Entity set 'XMLContext.Reference'  is null.");
          }
            _context.Reference.Add(reference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReference", new { id = reference.Id }, reference);
        }

        // DELETE: api/References/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReference(int id)
        {
            if (_context.Reference == null)
            {
                return NotFound();
            }
            var reference = await _context.Reference.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            _context.Reference.Remove(reference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenceExists(int id)
        {
            return (_context.Reference?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
