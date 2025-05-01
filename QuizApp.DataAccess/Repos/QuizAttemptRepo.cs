

namespace QuizApp.DataAccess.Repos
{
    public class QuizAttemptRepo : IQuizAttemptRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizAttemptRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(QuizAttempt attempt)
        {
            _context.QuizAttempts.Add(attempt);
            _context.SaveChanges();
        }

        public QuizAttempt GetById(int id)
        {
            return _context.QuizAttempts
                .Include(qa => qa.QuizNavigation)
                .Include(qa => qa.UserNavigation)
                .FirstOrDefault(qa => qa.Id == id);
        }

        public IEnumerable<QuizAttempt> GetByUserId(int userId)
        {
            return _context.QuizAttempts.Where(a => a.UserId == userId).ToList();
        }
    }
}
