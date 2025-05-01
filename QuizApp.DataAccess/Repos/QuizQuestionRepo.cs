namespace QuizApp.DataAccess.Repos
{
    public class QuizQuestionRepo : IQuizQuestionRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizQuestionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(QuizQuestion quizQuestion)
        {
            _context.QuizQuestions.Add(quizQuestion);
            _context.SaveChanges();
        }

        public IEnumerable<QuizQuestion> GetQuestionsByQuizId(int quizId)
        {
            return _context.QuizQuestions
                .Include(x => x.QuestionNavigation)
                .Where(x => x.QuizId == quizId)
                .ToList();
        }
    }
}
