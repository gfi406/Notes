using Microsoft.AspNetCore.Mvc;
using Notes.Services;
using Notes.Models;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetNotesAsync()
        {
            var note = await _noteService.GetNoteAsync();
            
            return Ok(note);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetByIdNoteAsync(Guid id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);
            return Ok(note);
    
        }

        [HttpPost]
        public async Task<ActionResult<Note>> AddNoteAsync(Note note)
        {
            var createdNote = await _noteService.AddNoteAsync(note);
            return Ok(createdNote);

        }

        [HttpPut("id")]
        public async Task<ActionResult<Note>> UpdateNoteAsync(Guid id, Note note)
        {
            var existingNote = await _noteService.GetNoteByIdAsync(id);
            if (existingNote == null)
            {
                return NotFound();
            }

            existingNote.Text = note.Text;
            existingNote.UpdateTimestamp();
            var updatednote = await _noteService.UpdateNoteAsync(existingNote);
            return Ok(updatednote);         

        }

        [HttpDelete("id")]
        public async Task<ActionResult<Note>> DeliteNoteAsync(Guid id)
        {
            var Note = await _noteService.GetNoteByIdAsync(id);
            if (Note == null)
            {
                return NotFound();
            }
            await _noteService.DeleteNoteByIdAsync(id);
            return Ok();

        }

        



    }
}
