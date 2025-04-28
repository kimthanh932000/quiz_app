namespace QuizApp.Models.Entities.Configuration
{
    public class AnswerChoiceConfiguration : IEntityTypeConfiguration<AnswerChoice>
    {
        public void Configure(EntityTypeBuilder<AnswerChoice> builder)
        {
            builder
                .Property(a => a.Text)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(a => a.IsCorrect)
                .HasDefaultValue(false);
        }
    }
}
