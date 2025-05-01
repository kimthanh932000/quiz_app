
namespace QuizApp.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionService(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task AddAsync(Question question)
        {
            _questionRepo.Add(question); ;
        }

        public async Task DeleteAsync(int id)
        {
            _questionRepo.Delete(id);
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return _questionRepo.GetAll();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return _questionRepo.GetById(id);
        }

        public async Task UpdateAsync(Question question)
        {
            _questionRepo.Update(question);
        }
    }
}
