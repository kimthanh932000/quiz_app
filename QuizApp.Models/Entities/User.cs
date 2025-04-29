namespace QuizApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<QuizAttempt> QuizAttempts { get; set; }
        public IEnumerable<Quiz> Quizzes { get; set; }
    }
}
