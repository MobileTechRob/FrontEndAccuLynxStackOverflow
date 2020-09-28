<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="FrontEndAccuLynxStackOverflow.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stack Over Flow - AccuLynx Project</title>
</head>
<body>
    <h3>StackOverFlow Questions and Answers - Demo App for AccuLynx</h3>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btnGetQuestions" Text="Get Questions" runat="server" OnClick="btnGetQuestions_Click" />
        <br />
        <br />
        <asp:ListView ID="StackOverFlowQuestionsListView" runat="server">           
            <LayoutTemplate>
                <table id ="Header" runat="server" border="1">
                    <tr id="tableheaderrow" title="Header Row" runat="server" onclick="questionClick">
                        <td id="QuestionTitle" runat="server"><b>Question Title</b></td>
                        <td id="QuestionBody" runat="server"><b>Question Body</b></td>                        
                    </tr>
                    <tr id="itemPlaceHolder">
                    </tr>                    
                </table>
            </LayoutTemplate>
            <ItemTemplate> 
                <tr id="row" runat="server">
                        <td align="center" runat="server">
                            <%# Eval("QuestionTitle") %>
                        </td>
                        <td align="center" runat="server">
                            <%# Eval("QuestionBody") %>
                        </td>
                        <td align="center" visible="false" runat="server">
                            <%# Eval("QuestionId") %>
                        </td>
                       <td id="QuestionViewAnswer"><asp:Button ID="btnViewAnswers" Text ="View Answers" runat="server" CommandName="ViewAnswers" CommandArgument='<%#Eval("QuestionId")%>' OnCommand="btnViewAnswers_Command" /></td>
                 </tr>
            </ItemTemplate>
        </asp:ListView>

        <asp:ListView ID="StackOverFlowAnswersListView" runat="server">           
            <LayoutTemplate>
                <table id ="Header" runat="server" border="1">
                    <tr id="tableheaderrow" title="Header Row" runat="server">
                        <td id="QuestionTitle" runat="server"><b>Answser Title</b></td>
                        <td id="QuestionBody" runat="server"><b>Answer Body</b></td>
                    </tr>
                    <tr id="itemPlaceHolder">
                    </tr>                    
                </table>
            </LayoutTemplate>
            <ItemTemplate> 
                <tr id="row" runat="server">
                        <td align="center" runat="server">
                            <%# Eval("QuestionTitle") %>
                        </td>
                        <td align="center" runat="server">
                            <%# Eval("QuestionBody") %>
                        </td>

                 </tr>
            </ItemTemplate>
        </asp:ListView>




    </form>
</body>
</html>

