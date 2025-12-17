namespace LogBookAPI.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string QuestionStatement { get; set; }

        public DateTime QuestionDate { get; set; }

        public DateTime AnswerDate { get; set; }

        public string Answer {  get; set; }
    }
}
