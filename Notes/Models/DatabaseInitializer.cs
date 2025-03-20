namespace Notes.Models
{
    public class DatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InitializeAsync()
        {
            
            
            await _context.Notes.AddAsync(new Note{ Text = "Hi!" } );
            await _context.SaveChangesAsync();
        }
    }
}
