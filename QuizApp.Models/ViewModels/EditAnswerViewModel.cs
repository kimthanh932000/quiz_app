namespace QuizApp.Models.ViewModels
{
    public class EditAnswerViewModel : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}
