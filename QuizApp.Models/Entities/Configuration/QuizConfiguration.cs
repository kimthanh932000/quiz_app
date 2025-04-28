namespace QuizApp.Models.Entities.Configuration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder
                .Property(q => q.TimeLimit)
                .IsRequired();

            builder
                .HasMany(q => q.Users)
                .WithMany(u => u.Quizzes)
                .UsingEntity<QuizAttempt>(
                    j => j
                             .HasOne(qa => qa.UserNavigation)
                             .WithMany(u => u.QuizAttempts)
                             .HasForeignKey(nameof(QuizAttempt.UserId)),
                    j => j
                         .HasOne(qa => qa.QuizNavigation)
                         .WithMany(q => q.QuizAttempts)
                         .HasForeignKey(nameof(QuizAttempt.QuizId)),
                    j =>
                    {
                        j.HasKey(qa => new { qa.UserId, qa.QuizId });
                    }                   
                );
        }
    }
}
