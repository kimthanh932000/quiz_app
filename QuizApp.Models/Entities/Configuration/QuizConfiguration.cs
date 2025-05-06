namespace QuizApp.Models.Entities.Configuration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder
                .HasMany(q => q.QuizAttempts)
                .WithOne(qa => qa.Quiz)
                .HasForeignKey(qa => qa.QuizId);
        }
    }
}
