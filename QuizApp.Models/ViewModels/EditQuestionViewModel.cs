namespace QuizApp.Models.ViewModels
{
    public class EditQuestionViewModel : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        [MinLength(1)]
        public List<EditAnswerViewModel> Options { get; set; }

        [Required]
        public int CorrectOption { get; set; }
    }
}
