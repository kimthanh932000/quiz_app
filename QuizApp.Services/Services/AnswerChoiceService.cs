namespace QuizApp.Services.Services
{
    public class AnswerChoiceService : IAnswerChoiceService
    {
        private readonly IAnswerChoiceRepo _answerChoiceRepo;

        public AnswerChoiceService(IAnswerChoiceRepo answerChoiceRepo)
        {
            _answerChoiceRepo = answerChoiceRepo;
        }

        public async Task AddAsync(AnswerChoice answerChoice)
        {
            await _answerChoiceRepo.AddAsync(answerChoice);
        }

        public async Task<IEnumerable<AnswerChoice>> GetByQuestionIdAsync(int id)
        {
            return await _answerChoiceRepo.GetByQuestionIdAsync(id);
        }

        public async Task UpdateAsync(AnswerChoice answerChoice)
        {
            await _answerChoiceRepo.UpdateAsync(answerChoice);
        }
    }
}
