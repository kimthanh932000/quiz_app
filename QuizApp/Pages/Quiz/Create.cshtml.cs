namespace QuizApp.Web.Pages.Quiz
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        private readonly IQuizService _quizService;
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuestionService _questionService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(
            IQuizService quizService,
            IQuizQuestionService quizQuestionService,
            IQuestionService questionService,
            ILogger<CreateModel> logger)
        {
            _quizService = quizService;
            _quizQuestionService = quizQuestionService;
            _questionService = questionService;
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
                await _quizService.AddAsync(new Models.Entities.Quiz { Name = Title });
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create the quiz.");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the quiz.");
                return Page();
            }
        }
    }
}
