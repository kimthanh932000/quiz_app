namespace QuizApp.Models.Entities
{
    public class AnswerChoice : BaseEntity
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }    //Navigation property
        public bool IsCorrect { get; set; }
    }
}
