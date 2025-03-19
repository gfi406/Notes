using Notes.Models;

namespace Notes.Services
{
    public interface INoteService 
    {
        Task<List<Note>> GetNoteAsync();

        Task<Note> GetNoteByIdAsync(Guid id);

        Task<Note> AddNoteAsync(Note note);
        Task<Note> UpdateNoteAsync(Note note);

        Task DeleteNoteByIdAsync(Guid id);

    }
}
