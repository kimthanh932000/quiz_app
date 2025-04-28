using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<AnswerChoice> AnswerChoices { get; set; }
    }
}
