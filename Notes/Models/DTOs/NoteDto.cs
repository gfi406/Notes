namespace Notes.Models.DTOs
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime UpdatedAt { get; set; }        

    }
}
