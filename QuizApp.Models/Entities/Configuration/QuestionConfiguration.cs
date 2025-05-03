namespace QuizApp.Models.Entities.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasMany(q => q.AnswerChoices)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            builder
                .HasMany(q => q.Quizzes)
                .WithMany(q => q.Questions)
                .UsingEntity<QuizQuestion>(
                    j => j
                         .HasOne(qq => qq.Quiz)
                         .WithMany(q => q.QuizQuestions)
                         .HasForeignKey(nameof(QuizQuestion.QuizId)),
                    j => j
                         .HasOne(qq => qq.Question)
                         .WithMany(q => q.QuizQuestions)
                         .HasForeignKey(nameof(QuizQuestion.QuestionId)),
                    j =>
                    {
                        j.HasKey(qq => new { qq.QuizId, qq.QuestionId });
                    }
                );

        }
    }
}
