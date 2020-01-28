using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetNotesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetNotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteContext _context;
        public NotesController(NoteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAll()
        {
            // Eager loading - Include must be specified to join related data
            var notes = await _context.Notes
                .Include(n => n.Type)
                .ToListAsync();
            return notes;
        }

        [HttpGet("{id}", Name = "GetNote")]
        public async Task<ActionResult<Note>> GetById(long id)
        {
            var item = await _context.Notes
                .Include(n => n.Type)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote([FromBody] Note note)
        {
            _context.Add(note);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new { id = note.Id }, note);
        }
    }
}