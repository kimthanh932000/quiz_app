namespace QuizApp.Models.Entities
{
    public class QuizAttempt : BaseEntity
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }    //Navigation property
        public string UserName { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }    //Navigation property
        public int Score { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
