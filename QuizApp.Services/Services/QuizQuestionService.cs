
namespace QuizApp.Services.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IQuizQuestionRepo _quizQuestionRepo;

        public QuizQuestionService(IQuizQuestionRepo quizQuestionRepo)
        {
            _quizQuestionRepo = quizQuestionRepo;
        }

        public async Task AddAsync(QuizQuestion quizQuestion)
        {
            _quizQuestionRepo.Add(quizQuestion);
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int id)
        {
            return _quizQuestionRepo.GetQuestionsByQuizId(id);
        }
    }
}
