namespace Notes.Models
{
    public class Note : BaseEntity
    {
        public String Text { get; set; }


        public Note() 
        { 
            Text  = string.Empty;
            UpdateTimestamp();
        }
    }
}
