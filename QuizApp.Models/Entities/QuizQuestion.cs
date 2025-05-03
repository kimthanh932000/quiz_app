namespace QuizApp.Models.Entities
{
    public class QuizQuestion : BaseEntity
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }  //Navigation property
        public int QuestionId { get; set; }
        public Question Question { get; set; }  //Navigation property
    }
}
