
namespace QuizApp.DataAccess.Repos
{
    public class QuizRepo : IQuizRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Quiz> AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                                .Include(x => x.QuizQuestions)
                                .ThenInclude(x => x.Question)
                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

    }
}
