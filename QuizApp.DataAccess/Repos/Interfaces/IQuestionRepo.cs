namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuestionRepo
    {
        Question GetById(int id);
        IEnumerable<Question> GetAll();
        void Add(Question question);
        void Update(Question question);
        void Delete(int id);
    }
}
