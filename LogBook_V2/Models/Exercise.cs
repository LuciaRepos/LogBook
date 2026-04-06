using System.ComponentModel.DataAnnotations;

namespace LogBook_V2.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public string ExerciseDescription { get; set; }
        public string Result { get; set; }
    }
}