namespace QuizApp.Web.Pages.Quiz
{
    public class AttemptModel : PageModel
    {
        public string QuizName { get; set; }

        [BindProperty]
        public List<AttemptQuestionViewModel> Data { get; set; }

        private readonly IQuizService _quizService;
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuizAttemptService _quizAttemptService;
        private readonly ILogger<CreateModel> _logger;

        public AttemptModel(
            IQuizService quizService,
            IQuizQuestionService quizQuestionService,
            IQuizAttemptService quizAttemptService,
            ILogger<CreateModel> logger)
        {
            _quizService = quizService;
            _quizQuestionService = quizQuestionService;
            _quizAttemptService = quizAttemptService;
            _logger = logger;

            Data = new List<AttemptQuestionViewModel>();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var quiz = await _quizService.GetByIdAsync(id);
                if (quiz == null)
                {
                    return NotFound();
                }
                QuizName = quiz.Name;

                var quizQuestions = (List<QuizQuestion>)await _quizQuestionService.GetQuestionsByQuizIdAsync(id);

                foreach (var qq in quizQuestions)
                {
                    Data.Add(new AttemptQuestionViewModel
                    {
                        Id = qq.Question.Id,
                        Text = qq.Question.Text,
                        Answers = qq.Question.AnswerChoices.ToList(),
                        SelectedAnswerId = 0,
                        CorrectAnswerId = qq.Question.AnswerChoices.First(a => a.IsCorrect).Id
                    });
                }
                
                var currentAttempt = new QuizAttempt
                {
                    QuizId = quiz.Id,
                    QuestionCount = quizQuestions.Count,
                    StartedAt = DateTime.UtcNow
                };

                // Persist "currentAttempt" object accross requests
                TempData["CurrentAttemp"] = JsonSerializer.Serialize(currentAttempt); // store serialized

                return Page();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start quiz.");
                ModelState.AddModelError(string.Empty, "An error occurred while starting the quiz.");
                return Page();
            }            
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                // Calculate scrore
                int correctCount = 0;

                foreach (var item in Data)
                {
                    if (item.SelectedAnswerId == item.CorrectAnswerId)
                    {
                        correctCount++;
                    }
                }
                // Update the persisted attempt object
                var currentAttempt = JsonSerializer.Deserialize<QuizAttempt>((string)TempData["CurrentAttemp"]);
                currentAttempt.Score = correctCount;
                currentAttempt.FinishedAt = DateTime.UtcNow;

                var attemptResult = await _quizAttemptService.AddAsync(currentAttempt);

                return RedirectToPage("Score", new { id = attemptResult.Id });

            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to submit quiz.");
                ModelState.AddModelError(string.Empty, "An error occurred while submitting quiz.");
                return Page();
            }
           
        }
    }
}
