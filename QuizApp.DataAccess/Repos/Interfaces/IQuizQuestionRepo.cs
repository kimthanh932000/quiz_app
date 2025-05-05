namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizQuestionRepo
    {
        Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId);
        Task AddAsync(QuizQuestion quizQuestion);
    }
}
