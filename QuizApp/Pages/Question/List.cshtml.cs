namespace QuizApp.Web.Pages.Question
{
    public class ListModel : PageModel
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<ListModel> _logger;

        public ListModel(IQuestionService questionService, ILogger<ListModel> logger)
        {
            _questionService = questionService;
            _logger = logger;
        }

        public List<Models.Entities.Question> Questions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Questions = new List<Models.Entities.Question>(await _questionService.GetAllAsync());
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch list of questions.");
                ModelState.AddModelError(string.Empty, "An error occurred while retreiving list of questions.");
                return Page();
            }
        }
    }
}
