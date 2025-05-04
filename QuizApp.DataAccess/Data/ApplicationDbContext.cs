namespace QuizApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AnswerChoice> AnswerChoices { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            new AnswerChoiceConfiguration().Configure(modelBuilder.Entity<AnswerChoice>());
            new QuestionConfiguration().Configure(modelBuilder.Entity<Question>());
            new QuizConfiguration().Configure(modelBuilder.Entity<Quiz>());
            new QuizAttemptConfiguration().Configure(modelBuilder.Entity<QuizAttempt>());
            new QuizQuestionConfiguration().Configure(modelBuilder.Entity<QuizQuestion>());
            //new UserConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
