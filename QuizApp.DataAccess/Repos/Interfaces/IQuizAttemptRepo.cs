namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizAttemptRepo
    {
        void Add(QuizAttempt attempt);
        QuizAttempt GetById(int id);
        IEnumerable<QuizAttempt> GetByUserId(int userId);
    }
}
