namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IAnswerChoiceRepo
    {
        Task<IEnumerable<AnswerChoice>> GetByQuestionIdAsync(int questionId);
        Task AddAsync(AnswerChoice answer);
        Task UpdateAsync(AnswerChoice answer);
    }
}
