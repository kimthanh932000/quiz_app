namespace QuizApp.Models.Entities
{
    public class Quiz : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<QuizQuestion> QuizQuestions { get; set; }
        public IEnumerable<QuizAttempt> QuizAttempts { get; set; }
    }
}
