namespace QuizApp.DataAccess.Repos
{
    public class AnswerChoiceRepo : IAnswerChoiceRepo
    {
        private readonly ApplicationDbContext _context;
        public AnswerChoiceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AnswerChoice answer)
        {
            await _context.AnswerChoices.AddAsync(answer);
            await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<AnswerChoice>> GetByQuestionIdAsync(int questionId)
        {
            return await _context.AnswerChoices.Where(a => a.QuestionId == questionId).ToListAsync();
        }

        public async Task UpdateAsync(AnswerChoice answer)
        {
            _context.AnswerChoices.Update(answer);
            await _context.SaveChangesAsync();
        }
    }
}
