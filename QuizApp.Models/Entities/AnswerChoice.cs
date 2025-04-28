namespace QuizApp.Models
{
    public class AnswerChoice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
