
namespace QuizApp.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionService(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task<Question> AddAsync(Question question)
        {
            return await _questionRepo.AddAsync(question);
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);
            if (question != null)
            {
                await _questionRepo.DeleteAsync(question);
            }
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _questionRepo.GetAllAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _questionRepo.GetByIdAsync(id);
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            return await _questionRepo.UpdateAsync(question);
        }
    }
}
