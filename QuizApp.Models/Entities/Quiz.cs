using QuizApp.Models.Entities;

namespace QuizApp.Models
{
    [EntityTypeConfiguration(typeof(QuizConfiguration))]
    public class Quiz : BaseEntity
    {
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<QuizQuestion> QuizQuestions { get; set; }
        public IEnumerable<QuizAttempt> QuizAttempts { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
