<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="QuestionAndAnswerPage.aspx.cs" Inherits="FrontEndAccuLynxStackOverflow.StartPage" %>

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
                <tr id="row" runat="server" style="width:50%;font:200;padding-left:2;padding-right:2;padding-top:2;padding-bottom:2">
                        <td align="center" runat="server" >
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
-        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="StackOverFlowQuestionsListView" PageSize="3" Visible ="false">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
        <br />
        <br />
        <asp:Label ID="lblSelectedQuestionsLabel" Text="Selected Question:" runat="server" Visible="false"></asp:Label>        
        <asp:Label ID="lblSelectedQuestions" Text="" runat="server"></asp:Label>        
        <br />
        <asp:ListView ID="StackOverFlowAnswersListView" runat="server">           
            <LayoutTemplate>
                <table id ="Header" runat="server" border="1">
                    <tr id="tableheaderrow" title="Header Row" runat="server">                        
                        <td id="AnswerBody" runat="server"><b>Answer Body</b></td>
                    </tr>
                    <tr id="itemPlaceHolder">
                    </tr>                    
                </table>
            </LayoutTemplate>
            <ItemTemplate> 
                <tr id="row" runat="server">
                        <td align="center" runat="server">
                            <%# Eval("Answer") %>
                        </td>
                        <td id="AnswerIsAccepted"><asp:Button ID="btnIsAcceptedAnswer" Text ="This is the Accepted Answer" runat="server" CommandName="DetermineAcceptedAnswer" CommandArgument='<%# Eval("AcceptedAnswer")%>' OnCommand="btnIsAcceptedAnswer_Command" /></td>
                 </tr>
            </ItemTemplate>
        </asp:ListView>               
    </form>
</body>
</html>

