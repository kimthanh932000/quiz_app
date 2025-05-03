
namespace QuizApp.Services.Services
{
    public class QuizAttemptService : IQuizAttemptService
    {
        private readonly IQuizAttemptRepo _quizAttemptRepo;

        public QuizAttemptService(IQuizAttemptRepo quizAttemptRepo)
        {
            _quizAttemptRepo = quizAttemptRepo;
        }

        public async Task AddAsync(QuizAttempt attempt)
        {
            _quizAttemptRepo.Add(attempt);
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
