namespace QuizApp.Services.Services.Interfaces
{
    public interface IQuizQuestionService
    {
        Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int id);
        Task AddAsync(QuizQuestion quizQuestion);
    }
}
