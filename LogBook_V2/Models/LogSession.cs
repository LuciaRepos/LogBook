using System.ComponentModel.DataAnnotations;

namespace LogBook_V2.Models
{
    public class LogSession
    {
        [Key]
        public int SessionID { get; set; }
        public DateTime SessionDate { get; set; }
        public int DurationMinutes { get; set; }
        public string SessionDescription { get; set; }
    }
}