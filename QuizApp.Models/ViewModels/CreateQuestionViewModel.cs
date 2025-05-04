namespace QuizApp.Models.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Text { get; set; }

        [MinLength(1)]
        public List<CreateAnswerViewModel> Options { get; set; }

        [Required]
        public int CorrectOption { get; set; }
    }
}
