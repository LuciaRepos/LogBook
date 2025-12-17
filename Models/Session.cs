namespace LogBookAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int SessionDate { get; set; }
        public int DurationMinutes { get; set; }
        public string SessionDescription { get; set; }
    }
}
