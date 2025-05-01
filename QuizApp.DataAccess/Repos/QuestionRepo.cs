namespace QuizApp.DataAccess.Repos
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions.Include(q => q.AnswerChoices).ToList();
        }

        public Question GetById(int id)
        {
            return _context.Questions.Include(q => q.AnswerChoices).FirstOrDefault(q => q.Id == id);
        }
        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }
    }
}
