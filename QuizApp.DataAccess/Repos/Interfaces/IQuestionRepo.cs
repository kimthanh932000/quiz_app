namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuestionRepo
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> AddAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        //void Delete(int id);
    }
}
