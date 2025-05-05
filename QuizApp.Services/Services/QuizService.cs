
namespace QuizApp.Services.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepo _quizRepo;

        public QuizService(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<Quiz> AddAsync(Quiz quiz)
        {
            return await _quizRepo.AddAsync(quiz);
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _quizRepo.GetByIdAsync(id);
            if (quiz == null)
            {
                throw new KeyNotFoundException($"Quiz {id} not found");
            }
            await _quizRepo.DeleteAsync(quiz);
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _quizRepo.GetAllAsync();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return await _quizRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            await _quizRepo.UpdateAsync(quiz);
        }
    }
}
