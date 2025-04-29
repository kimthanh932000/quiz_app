namespace QuizApp.Models.Entities
{
    public class QuizQuestion : BaseEntity
    {
        public int QuizId { get; set; }
        public Quiz QuizNavigation { get; set; }
        public int QuestionId { get; set; }
        public Question QuestionNavigation { get; set; }
    }
}
