namespace QuizApp.Models.ViewModels
{
    public class CreateQuizViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> SelectedQuestionIds { get; set; }
    }
}
