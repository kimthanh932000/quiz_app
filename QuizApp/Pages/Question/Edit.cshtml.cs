namespace QuizApp.Web.Pages.Question
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Models.Entities.Question Question { get; set; }

        [BindProperty]
        public List<AnswerChoice> AnswerChoices { get; set; }

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
            AnswerChoices = new List<AnswerChoice>();
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Question = await _questionService.GetByIdAsync(id);
                if (Question == null)
                {
                    return NotFound();
                }

                AnswerChoices.AddRange(await _answerChoiceService.GetByQuestionIdAsync(id));
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch the question.");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving the question.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await _questionService.UpdateAsync(Question);

                foreach (var choice in AnswerChoices)
                {
                    if (string.IsNullOrWhiteSpace(choice.Text))
                        continue;

                    if (choice.Id == 0)
                    {
                        await _answerChoiceService.AddAsync(choice);
                    }
                    else
                    {
                        await _answerChoiceService.UpdateAsync(choice);
                    }
                }

                return RedirectToPage("List");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update the question.");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the question.");
                return Page();
            }
        }
    }
}
