namespace QuizApp.Web.Pages.Quiz.Question
{
    public class EditModel : PageModel
    {
        [BindProperty] 
        public EditQuestionViewModel Data { get; set; }

        private readonly IQuestionService _questionService;
        private readonly IAnswerChoiceService _answerChoiceService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(
            IQuestionService questionService,
            IAnswerChoiceService answerChoiceService,
            ILogger<EditModel> logger)
        {
            _questionService = questionService;
            _answerChoiceService = answerChoiceService;
            _logger = logger;

            Data = new EditQuestionViewModel
            {
                Options = new List<EditAnswerViewModel>()
            };
        }

        public async Task<IActionResult> OnGetAsync(int questionId)
        {
            try
            {
                var question = await _questionService.GetByIdAsync(questionId);
                if (question == null)
                {
                    return NotFound();
                }

                Data.Id = question.Id;
                Data.Text = question.Text;

                var options = await _answerChoiceService.GetByQuestionIdAsync(questionId);

                Data.Options.AddRange(options.Select(x => new EditAnswerViewModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    QuestionId = x.QuestionId,
                    IsCorrect = x.IsCorrect
                }).ToList());

                Data.CorrectOption = Data.Options.FindIndex(o => o.IsCorrect);

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch the question.");
                ModelState.AddModelError("", "An error occurred while retrieving the question.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int quizId, int questionId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var question = new Models.Entities.Question
                {
                    Id = questionId,
                    Text = Data.Text,
                };

                await _questionService.UpdateAsync(question);

                for (int i = 0; i < Data.Options.Count; i++)
                {
                    await _answerChoiceService.UpdateAsync(new AnswerChoice
                    {
                        Id = Data.Options[i].Id,
                        QuestionId = questionId,
                        Text = Data.Options[i].Text,
                        IsCorrect = (i == Data.CorrectOption)
                    });

                }

                return RedirectToPage("/Quiz/Edit", new { id = quizId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update the question.");
                ModelState.AddModelError("", "An error occurred while updating the question.");
                return Page();
            }
        }
    }
}
