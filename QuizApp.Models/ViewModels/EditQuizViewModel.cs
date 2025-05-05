namespace QuizApp.Models.ViewModels
{
    public class EditQuizViewModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
