
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
            await _quizQuestionRepo.AddAsync(quizQuestion);
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int id)
        {
            return await _quizQuestionRepo.GetQuestionsByQuizIdAsync(id);
        }
    }
}
