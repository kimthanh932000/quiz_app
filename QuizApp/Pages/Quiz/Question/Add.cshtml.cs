namespace QuizApp.Web.Pages.Quiz.Question
{
    public class AddModel : PageModel
    {
        // this will be populated from the URL
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateQuestionViewModel Data { get; set; }

        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerChoiceService _answerChoiceService;
        private readonly ILogger<CreateModel> _logger;

        public AddModel(
            IQuizQuestionService quizQuestionService,
            IQuestionService questionService,
            IAnswerChoiceService answerChoiceService,
            ILogger<CreateModel> logger)
        {
            _quizQuestionService = quizQuestionService;
            _questionService = questionService;
            _answerChoiceService = answerChoiceService;
            _logger = logger;

            Data = new CreateQuestionViewModel
            {
                Options = new List<CreateAnswerViewModel> { new(), new(), new() }
            };
        }

        public void OnGet()
        {
            //
        }

        public async Task<Models.Entities.Question> AddAsync(Models.Entities.Question question)
        {
            _questionService.AddAsync(question);
            return question;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (Data.Options.Count == 0)
                {
                    ModelState.AddModelError("", "Please add at least one option.");
                    return Page();
                }

                var question = await _questionService.AddAsync(new Models.Entities.Question
                {
                    Text = Data.Text
                });

                for (int i = 0; i < Data.Options.Count; i++)
                {
                    AnswerChoice option = new();
                    option.QuestionId = question.Id;
                    option.Text = Data.Options[i].Text;
                    option.IsCorrect = i == Data.CorrectOption;
                    await _answerChoiceService.AddAsync(option);
                }

                await _quizQuestionService.AddAsync(new QuizQuestion { QuestionId = question.Id, QuizId = id });

                return RedirectToPage("/Quiz/Edit", new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save the question.");
                ModelState.AddModelError("", "An error occurred while saving the question.");
                return Page();
            }
        }
    }
}
