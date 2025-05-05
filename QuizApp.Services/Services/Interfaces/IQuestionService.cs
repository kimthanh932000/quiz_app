namespace QuizApp.Services.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> AddAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
