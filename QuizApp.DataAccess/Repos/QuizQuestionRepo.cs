namespace QuizApp.DataAccess.Repos
{
    public class QuizQuestionRepo : IQuizQuestionRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizQuestionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuizQuestion quizQuestion)
        {
            await _context.QuizQuestions.AddAsync(quizQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.QuizQuestions
                .Include(x => x.Question)
                .ThenInclude(q => q.AnswerChoices)
                .Where(x => x.QuizId == quizId)
                .ToListAsync();
        }
    }
}
