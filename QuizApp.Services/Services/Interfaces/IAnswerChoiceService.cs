namespace QuizApp.Services.Services.Interfaces
{
    public interface IAnswerChoiceService
    {
        Task<IEnumerable<AnswerChoice>> GetByQuestionIdAsync(int id);
        Task AddAsync(AnswerChoice answerChoice);
        Task UpdateAsync(AnswerChoice answerChoice);
        Task DeleteAsync(int id);
    }
}
