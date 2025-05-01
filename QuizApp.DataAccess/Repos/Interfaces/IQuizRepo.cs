namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizRepo
    {
        Quiz GetById(int id);
        IEnumerable<Quiz> GetAll();
        void Add(Quiz quiz);
    }
}
