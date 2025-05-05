namespace QuizApp.Web.Pages.Quiz
{
    public class ListModel : PageModel
    {
        public List<Models.Entities.Quiz> Quizzes { get; set; }

        private readonly IQuizService _quizService;
        private readonly ILogger<ListModel> _logger;

        public ListModel(IQuizService quizService, ILogger<ListModel> logger)
        {
            _quizService = quizService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Quizzes = new List<Models.Entities.Quiz>(await _quizService.GetAllAsync());
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch list of quizzes.");
                ModelState.AddModelError(string.Empty, "An error occurred while retreiving list of quizzes.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _quizService.DeleteAsync(id);
                return RedirectToPage();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete quiz.");
                ModelState.AddModelError(string.Empty, "An error occurred while trying to delete quiz.");
                return Page();
            }
        }
    }
}
