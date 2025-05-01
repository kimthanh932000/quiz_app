
namespace QuizApp.Services.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepo _quizRepo;

        public QuizService(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task AddAsync(Quiz quiz)
        {
            _quizRepo.Add(quiz);
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return _quizRepo.GetAll();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return _quizRepo.GetById(id);
        }
    }
}
