using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndAccuLynxStackOverflow.StackAppDataClasses
{
    public class StackAppQuestion
    {
        private List<StackAppAnswer> answers;

        public String Title;
        public String Body;
        public int AnswerID;

        public StackAppQuestion(List<StackAppAnswer> answers) { this.answers = answers; }
        public StackAppQuestion(string questionTitle, string questionText) { this.Title = questionTitle; this.Body = questionText; }

        public void AddAnswer(StackAppAnswer answer) { answers.Add(answer); }
    }

    public class StackAppAnswer
    {
        public String Title;
        public String Body;
        public int QuestionId;
        public int AnswerId;
        public bool AcceptedAnswer;

       public StackAppAnswer(String Title, String Body, int AnswerId, int QuestionId, bool AcceptedAnswer) 
       {
        this.Title = Title;
        this.Body = Body;
        this.QuestionId = QuestionId;
        this.AnswerId = AnswerId;
        this.AcceptedAnswer = AcceptedAnswer;
       }
    }   
}


