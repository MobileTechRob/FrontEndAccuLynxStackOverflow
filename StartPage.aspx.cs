using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEndAccuLynxStackOverflow.StackAppDataClasses;

namespace FrontEndAccuLynxStackOverflow
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable tableForQuestionsListview = new DataTable();

            tableForQuestionsListview.Columns.Add("QuestionTitle", System.Type.GetType("System.String"));
            tableForQuestionsListview.Columns.Add("QuestionBody", System.Type.GetType("System.String"));
            tableForQuestionsListview.Columns.Add("QuestionId", System.Type.GetType("System.String"));

            tableForQuestionsListview.Rows.Add(new object[] { "a question title", "a question body", "1245" });
            tableForQuestionsListview.Rows.Add(new object[] { "a question title 2", "a question body","3456" });
            

            StackOverFlowQuestionsListView.DataSource = tableForQuestionsListview;
            StackOverFlowQuestionsListView.DataBind();
        }

        protected void btnViewAnswers_Command(object sender, CommandEventArgs e)
        {

            DataTable tableForAnswersListview = new DataTable();

            tableForAnswersListview.Columns.Add("QuestionTitle", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("QuestionBody", System.Type.GetType("System.String"));
            tableForAnswersListview.Columns.Add("QuestionId", System.Type.GetType("System.String"));

            tableForAnswersListview.Rows.Add(new object[] { "an answer title", "an answer body", "1245" });
            tableForAnswersListview.Rows.Add(new object[] { "an answer title 2", "an answer body2", "3456" });
                         
        }

        protected void btnGetQuestions_Click(object sender, EventArgs e)
        {

        }
    }
}