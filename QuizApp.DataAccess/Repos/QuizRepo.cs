
namespace QuizApp.DataAccess.Repos
{
    public class QuizRepo : IQuizRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _context.Quizzes.ToList();
        }

        public Quiz GetById(int id)
        {
            return _context.Quizzes
                                .Include(x => x.QuizQuestions)
                                .ThenInclude(x => x.QuestionNavigation)
                                .FirstOrDefault(x => x.Id == id);
        }
    }
}
