
namespace QuizApp.Services.Services
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly IQuizAttemptRepo _quizAttemptRepo;

        public QuizAttemptService(IQuizAttemptRepo quizAttemptRepo)
        {
            _quizAttemptRepo = quizAttemptRepo;
        }

        public async Task<QuizAttempt> AddAsync(QuizAttempt attempt)
        {
            return await _quizAttemptRepo.AddAsync(attempt);
        }

        public async Task<QuizAttempt> GetByIdAsync(int id)
        {
            return _quizAttemptRepo.GetById(id);
        }

        //public async Task<IEnumerable<QuizAttempt>> GetByUserIdAsync(int id)
        //{
        //    return _quizAttemptRepo.GetByUserId(id);
        //}
    }
}
