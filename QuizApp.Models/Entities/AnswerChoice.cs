namespace QuizApp.Models
{
    [EntityTypeConfiguration(typeof(AnswerChoiceConfiguration))]
    public class AnswerChoice : BaseEntity
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question QuestionNavigation { get; set; }
        public bool IsCorrect { get; set; }
    }
}
