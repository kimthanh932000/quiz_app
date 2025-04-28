namespace QuizApp.Models
{
    public class Quiz : BaseEntity
    {
        public int TimeLimit { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
