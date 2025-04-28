namespace QuizApp.Models
{
    [EntityTypeConfiguration(typeof(QuizAttemptConfiguration))]
    public class QuizAttempt : BaseEntity
    {
        public int QuizId { get; set; }
        public Quiz QuizNavigation { get; set; }
        public int UserId { get; set; }
        public User UserNavigation { get; set; }
        public int Score { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
