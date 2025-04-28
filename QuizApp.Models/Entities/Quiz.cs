using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int TimeLimit { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
