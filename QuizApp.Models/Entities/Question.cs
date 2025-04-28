namespace QuizApp.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public ICollection<AnswerChoice> AnswerChoices { get; set; }
    }
}
