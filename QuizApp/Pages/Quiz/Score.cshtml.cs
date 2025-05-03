namespace QuizApp.Web.Pages.Quiz
{
    public class ScoreModel : PageModel
    {
        public QuizAttempt Attempt { get; set; }

        private readonly IQuizAttemptService _attemptService;
        private readonly ILogger<ScoreModel> _logger;

        public ScoreModel(IQuizAttemptService attemptService, ILogger<ScoreModel> logger)
        {
            _attemptService = attemptService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Attempt = await _attemptService.GetByIdAsync(id);
                if (Attempt == null)
                {
                    return NotFound();
                }
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch quiz result.");
                ModelState.AddModelError(string.Empty, "An error occurred while retreiving the quiz result.");
                return Page();
            }
        }

    }
}
