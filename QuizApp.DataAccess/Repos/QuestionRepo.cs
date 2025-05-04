namespace QuizApp.DataAccess.Repos
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Question> AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        //public void Delete(int id)
        //{
        //    var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        //    if (question != null)
        //    {
        //        _context.Questions.Remove(question);
        //        _context.SaveChanges();
        //    }
        //}

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.Include(q => q.AnswerChoices).ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions.Include(q => q.AnswerChoices).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }
    }
}
