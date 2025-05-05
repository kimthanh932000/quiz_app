namespace QuizApp.Services.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> GetByIdAsync(int id);
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz> AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(int id);
    }
}
