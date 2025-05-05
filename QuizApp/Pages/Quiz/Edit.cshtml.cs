namespace QuizApp.Web.Pages.Quiz
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditQuizViewModel Data { get; set; }

        public List<QuizQuestion> QuizQuestions { get; set; }

        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IQuizService quizService, IQuestionService questionService, IQuizQuestionService quizQuestionService, ILogger<EditModel> logger)
        {
            _quizService = quizService;
            _questionService = questionService;
            _quizQuestionService = quizQuestionService;
            _logger = logger;
            Data = new EditQuizViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var quiz = await _quizService.GetByIdAsync(id);
                Data.Id = quiz.Id;
                Data.Name = quiz.Name;

                QuizQuestions = new List<QuizQuestion>(await _quizQuestionService.GetQuestionsByQuizIdAsync(id));
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch quiz details.");
                ModelState.AddModelError(string.Empty, "An error occurred while retreiving quiz details.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await _quizService.UpdateAsync(new Models.Entities.Quiz
                {
                    Id = id,
                    Name = Data.Name
                });
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update quiz.");
                ModelState.AddModelError(string.Empty, "An error occurred while updating quiz.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _questionService.DeleteAsync(id);
                return RedirectToPage(new { id = Data.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete question.");
                ModelState.AddModelError(string.Empty, "An error occurred while trying to delete question.");
                return Page();
            }
        }
    }
}
