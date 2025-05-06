namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizAttemptRepo
    {
        Task<QuizAttempt> AddAsync(QuizAttempt attempt);
        QuizAttempt GetById(int id);
    }
}
