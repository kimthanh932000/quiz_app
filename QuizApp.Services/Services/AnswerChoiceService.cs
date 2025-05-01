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
            _answerChoiceRepo.Add(answerChoice);
        }

        public async Task DeleteAsync(int id)
        {
            _answerChoiceRepo.Delete(id);
        }

        public async Task<IEnumerable<AnswerChoice>> GetByQuestionIdAsync(int id)
        {
            return _answerChoiceRepo.GetByQuestionId(id);
        }

        public async Task UpdateAsync(AnswerChoice answerChoice)
        {
            _answerChoiceRepo.Update(answerChoice);
        }
    }
}
