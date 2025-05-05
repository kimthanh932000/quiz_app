namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizRepo
    {
        Task<Quiz> GetByIdAsync(int id);
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz> AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(Quiz quiz);
    }
}
