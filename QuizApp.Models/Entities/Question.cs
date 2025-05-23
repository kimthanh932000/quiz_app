﻿namespace QuizApp.Models.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public IEnumerable<AnswerChoice> AnswerChoices { get; set; }
        public IEnumerable<Quiz> Quizzes { get; set; }
        public IEnumerable<QuizQuestion> QuizQuestions { get; set; }
    }
}
