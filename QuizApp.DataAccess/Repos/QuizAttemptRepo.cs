﻿

namespace QuizApp.DataAccess.Repos
{
    public class QuizAttemptRepo : IQuizAttemptRepo
    {
        private readonly ApplicationDbContext _context;

        public QuizAttemptRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QuizAttempt> AddAsync(QuizAttempt attempt)
        {
            await _context.QuizAttempts.AddAsync(attempt);
            await _context.SaveChangesAsync();
            return attempt;
        }

        public QuizAttempt GetById(int id)
        {
            return _context.QuizAttempts
                .Include(qa => qa.Quiz)
                .FirstOrDefault(qa => qa.Id == id);
        }
    }
}
