namespace QuizApp.Models.ViewModels
{
    public class AttemptQuestionViewModel : BaseEntity
    {

        [Required]
        public string Text { get; set; }

        [Required]
        public List<AnswerChoice> Answers { get; set; }

        public int? SelectedAnswerId { get; set; }

        public int CorrectAnswerId { get; set; }
    }
}
