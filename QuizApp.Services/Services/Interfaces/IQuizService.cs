namespace QuizApp.Services.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> GetByIdAsync(int id);
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task AddAsync(Quiz quiz);
    }
}
