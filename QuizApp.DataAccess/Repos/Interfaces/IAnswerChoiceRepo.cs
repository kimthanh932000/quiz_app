namespace QuizApp.DataAccess.Repos.Interfaces
{
    public interface IAnswerChoiceRepo
    {
        IEnumerable<AnswerChoice> GetByQuestionId(int questionId);
        void Add(AnswerChoice answer);
        void Update(AnswerChoice answer);
        void Delete(int id);
    }
}
