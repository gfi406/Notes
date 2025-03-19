using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public async Task<List<Note>> GetNoteAsync()
        {
            return await _context.Notes.ToListAsync();
        }
        public async Task<Note> GetNoteByIdAsync(Guid id)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

        }

        public async Task<Note> AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note> UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task DeleteNoteByIdAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();

            }
        }


    }
}
