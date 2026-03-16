namespace LogBookAPI.Models
{
    public class LogSession
    {
        public int Id { get; set; }

        public int SessionDate { get; set; }
        
        public int DurationMinutes { get; set; }
        
        public string SessionDescription { get; set; }
    }
}
