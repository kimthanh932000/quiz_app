namespace QuizApp.Web.Pages.Quiz
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Entities.Quiz Quiz { get; set; }

        [BindProperty]
        public List<int> SelectedQuestionIds { get; set; }

        public List<Models.Entities.Question> AllQuestions { get; set; }

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

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                AllQuestions = new List<Models.Entities.Question>(await _questionService.GetAllAsync());
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch list of questions.");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving list of questions.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Quiz name is required.");
                    return Page();
                }

                await _quizService.AddAsync(Quiz);

                var quizQuestions = SelectedQuestionIds.Select(qId => new QuizQuestion
                {
                    QuizId = Quiz.Id,
                    QuestionId = qId
                }).ToList();

                foreach (var qq in quizQuestions)
                {
                    await _quizQuestionService.AddAsync(qq);
                }

                return RedirectToPage("List");
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
