namespace QuizApp.DataAccess.Repos
{
    public class AnswerChoiceRepo : IAnswerChoiceRepo
    {
        private readonly ApplicationDbContext _context;
        public AnswerChoiceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AnswerChoice answer)
        {
            _context.AnswerChoices.Add(answer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var answer = _context.AnswerChoices.FirstOrDefault(a => a.Id == id);
            if (answer != null)
            {
                _context.AnswerChoices.Remove(answer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<AnswerChoice> GetByQuestionId(int questionId)
        {
            return _context.AnswerChoices.Where(a => a.QuestionId == questionId).ToList();
        }

        public void Update(AnswerChoice answer)
        {
            _context.AnswerChoices.Update(answer);
            _context.SaveChanges();
        }
    }
}
