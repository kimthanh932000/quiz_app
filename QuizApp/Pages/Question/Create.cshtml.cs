namespace QuizApp.Web.Pages.Question
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Entities.Question Question { get; set; }

        [BindProperty]
        public List<AnswerChoice> AnswerChoices { get; set; }

        private readonly IQuestionService _questionService;
        private readonly IAnswerChoiceService _answerChoiceService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(
            IQuestionService questionService, 
            IAnswerChoiceService answerChoiceService,
            ILogger<CreateModel> logger)
        {
            _questionService = questionService;
            _answerChoiceService = answerChoiceService;
            _logger = logger;
        }

        public void OnGet()
        {
            //
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await _questionService.AddAsync(Question);

                foreach (var choice in AnswerChoices)
                {
                    choice.QuestionId = Question.Id;
                    await _answerChoiceService.AddAsync(choice);
                }

                return RedirectToPage("List");
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save the question.");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the question.");
                return Page();
            }          
        }
    }
}
