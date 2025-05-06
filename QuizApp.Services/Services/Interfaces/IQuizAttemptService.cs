namespace QuizApp.Services.Services.Interfaces
{
    public interface IQuizAttemptService
    {
        Task<QuizAttempt> AddAsync(QuizAttempt attempt);
        Task<QuizAttempt> GetByIdAsync(int id);
        //Task<IEnumerable<QuizAttempt>> GetByUserIdAsync(int id);
    }
}
