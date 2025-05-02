using System.Text.Json;

namespace QuizApp.Web.Pages.Quiz
{
    public class AttemptModel : PageModel
    {
        [BindProperty]
        public Models.Entities.Quiz Quiz { get; set; }
        [BindProperty]
        public List<Models.Entities.Question> Questions { get; set; }
        [BindProperty]
        public Dictionary<int, int> Answers { get; set; } // Key = QuestionId, Value = SelectedAnswerId
        //public QuizAttempt CurrentAttempt { get; set; }

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
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Quiz = await _quizService.GetByIdAsync(id);
            if (Quiz == null)
            {
                return NotFound();
            }
            // Should save this attempt to db
            var currentAttempt = new QuizAttempt
            {
                UserName = "Vee",
                //UserNavigation = new User { UserName = User.Identity.Name }, // or another property
                StartedAt = DateTime.UtcNow
            };
            // Persist CurrentAttempt object accross requests
            TempData["AttemptStart"] = JsonSerializer.Serialize(currentAttempt); // store serialized

            Questions = (List<Models.Entities.Question>)await _quizQuestionService.GetQuestionsByQuizIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, "Please answer at least one question.");
                return Page();
            }

            // Calculate scrore
            int correctCount = 0;

            foreach (var item in Answers)
            {
                int questionId = item.Key;
                int selectedAnswerId = item.Value;

                var question = Questions.FirstOrDefault(q => q.Id == questionId);
                var selected = question?.AnswerChoices.FirstOrDefault(c => c.Id == selectedAnswerId);

                if (selected?.IsCorrect == true)
                {
                    correctCount++;
                }
            }
            // Update the persisted attempt object
            var attempt = JsonSerializer.Deserialize<QuizAttempt>((string)TempData["AttemptStart"]);

            attempt.QuizId = Quiz.Id;
            attempt.Score = correctCount;
            attempt.FinishedAt = DateTime.UtcNow;

            await _quizAttemptService.AddAsync(attempt);
            //TempData["Score"] = $"{correctCount} / {Answers.Count}";
            return RedirectToPage("Score", new { id = Quiz.Id });
        }
    }
}
