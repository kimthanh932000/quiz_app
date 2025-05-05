namespace QuizApp.Web.Pages.Quiz
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }
        //[BindProperty]
        //public CreateQuizViewModel Data { get; set; }

        //public List<Models.Entities.Question> AllQuestions { get; set; }

        // Holds all questions for the select‐list
        //public List<SelectListItem> QuestionList { get; set; }

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

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    try
        //    {
        //        var questions = await _questionService.GetAllAsync();
        //        QuestionList = questions
        //            .OrderBy(q => q.Text)
        //            .Select(q => new SelectListItem
        //            {
        //                Value = q.Id.ToString(),
        //                Text = q.Text
        //            }).ToList();
        //        return Page();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to fetch list of questions.");
        //        ModelState.AddModelError(string.Empty, "An error occurred while retrieving list of questions.");
        //        return Page();
        //    }
        //}
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

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            ModelState.AddModelError(string.Empty, "Quiz name is required.");
        //            return Page();
        //        }

        //        var quiz = await _quizService.AddAsync(new Models.Entities.Quiz { Name = Data.Name });

        //        var quizQuestions = Data.SelectedQuestionIds.Select(qId => new QuizQuestion
        //        {
        //            QuizId = quiz.Id,
        //            QuestionId = qId
        //        }).ToList();

        //        foreach (var qq in quizQuestions)
        //        {
        //            await _quizQuestionService.AddAsync(qq);
        //        }

        //        return RedirectToPage("List");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to create the quiz.");
        //        ModelState.AddModelError(string.Empty, "An error occurred while saving the quiz.");
        //        return Page();
        //    }
        //}
    }
}
