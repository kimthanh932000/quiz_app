namespace QuizApp.Models.Entities.Configuration
{
    public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder
                .Property(qa => qa.Score)
                .IsRequired()
                .HasDefaultValue(0);

            builder
                .Property(qa => qa.StartedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
        }
    }
}
