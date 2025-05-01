namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IQuizQuestionRepo
    {
        IEnumerable<QuizQuestion> GetQuestionsByQuizId(int quizId);
        void Add(QuizQuestion quizQuestion);
    }
}
