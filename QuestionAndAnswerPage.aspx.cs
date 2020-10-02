using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEndAccuLynxStackOverflow.StackAppDataClasses;
using StackExchange.StacMan;
using System.Threading.Tasks;

namespace FrontEndAccuLynxStackOverflow
{
    public partial class StartPage : System.Web.UI.Page
    {
        StackExchange.StacMan.StacManClient stackAppClient = new StackExchange.StacMan.StacManClient("IWxKGhjr9yw)JT7GHEQGaA((", "2.1");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // first time loading the page so lets retrieve the data from the api
            if (IsPostBack == false)
            {
                DateTime startDate = DateTime.Now.AddDays(-1);
                DateTime endDate = DateTime.Now;
        
                Task<StackExchange.StacMan.StacManResponse<Question>> mainQueryQuestiontask = stackAppClient.Search.GetMatchesAdvanced("stackoverflow.com", "withbody", null, null, startDate, endDate, null, null, null, null, null, null, null, true, 2);

                StacManResponse<Question> listOfQuestions = mainQueryQuestiontask.Result;
                            
                List<int> listOfQuestionIds = new List<int>();

                foreach (Question q in listOfQuestions.Data.Items)
                {
                    listOfQuestionIds.Add(q.QuestionId);
                }

                // now we have a list of questions with an accepted answer and more than one answer.
                // for each question
                // get the question title and question body  .. this will be one row.

                // get the question title and bodies and accepted answer id associated with list of question ids.
                Task<StackExchange.StacMan.StacManResponse<Question>> questionstask = stackAppClient.Questions.GetByIds("stackoverflow.com", listOfQuestionIds, "withbody");
                StackExchange.StacMan.StacManResponse<Question> listOfQuestionInfo = questionstask.Result;

                DataTable tableForQuestionsListview = new DataTable();

                tableForQuestionsListview.Columns.Add("QuestionTitle", System.Type.GetType("System.String"));
                tableForQuestionsListview.Columns.Add("QuestionBody", System.Type.GetType("System.String"));
                tableForQuestionsListview.Columns.Add("QuestionId", System.Type.GetType("System.Int32"));


                foreach (Question question in listOfQuestionInfo.Data.Items)
                {
                    tableForQuestionsListview.Rows.Add(new object[] {question.Title, question.Body,  question.QuestionId });
                }

                StackOverFlowQuestionsListView.DataSource = tableForQuestionsListview;
                StackOverFlowQuestionsListView.DataBind();                
            }
           
        }

        protected async void btnViewAnswers_Command(object sender, CommandEventArgs e)
        {
            lblSelectedQuestionsLabel.Visible = true;

            DataTable tableForAnswersListview = new DataTable();
            
            tableForAnswersListview.Columns.Add("Answer", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("AcceptedAnswer", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("QuestionId", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("AnswerId", System.Type.GetType("System.String"));

            List<Int32> listOfQuestionIds = new List<int>();
            listOfQuestionIds.Add(Int32.Parse(e.CommandArgument.ToString()));

            Task<StackExchange.StacMan.StacManResponse<Question>> selectedQuestionTask = stackAppClient.Questions.GetByIds("stackoverflow.com", listOfQuestionIds, "withbody");
            StackExchange.StacMan.StacManResponse<Question> selectedQuestion = selectedQuestionTask.Result;
            lblSelectedQuestions.Text = selectedQuestion.Data.Items[0].Title;

            Task<StackExchange.StacMan.StacManResponse<Answer>> answerstask = stackAppClient.Questions.GetAnswers("stackoverflow.com", listOfQuestionIds, "withbody");
            StackExchange.StacMan.StacManResponse<Answer> listOfAnswerInfo = answerstask.Result;

            Action<StackExchange.StacMan.StacManResponse<Answer>> listAnswersDel = DisplayAnswers;

            listAnswers.Method = "DisplayAnswers";

            answerstask.GetAwaiter().OnCompleted()


            foreach (Answer answer in listOfAnswerInfo.Data.Items)
            {                   
                tableForAnswersListview.Rows.Add(new object[] {answer.Body, answer.IsAccepted, answer.AnswerId});
            }

            StackOverFlowAnswersListView.DataSource = tableForAnswersListview;
            StackOverFlowAnswersListView.DataBind();
        }

        public void DisplayAnswers(StackExchange.StacMan.StacManResponse<Answer> answerlist)
        {
            DataTable tableForAnswersListview = new DataTable();

            tableForAnswersListview.Columns.Add("Answer", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("AcceptedAnswer", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("QuestionId", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("AnswerId", System.Type.GetType("System.String"));

            foreach (Answer answer in answerlist.Data.Items)
            {
                tableForAnswersListview.Rows.Add(new object[] { answer.Body, answer.IsAccepted, answer.AnswerId });
            }

            StackOverFlowAnswersListView.DataSource = tableForAnswersListview;
            StackOverFlowAnswersListView.DataBind();
        }

        protected void btnIsAcceptedAnswer_Command(object sender, CommandEventArgs e)
        {
            Button btn = (Button)sender;

            if (e.CommandArgument.ToString().Equals(Boolean.TrueString))                
                btn.BackColor = System.Drawing.Color.Green;             
            else
                btn.BackColor = System.Drawing.Color.Red;
        }
    }
}