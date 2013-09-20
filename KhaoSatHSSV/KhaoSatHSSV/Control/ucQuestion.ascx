<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucQuestion.ascx.cs" Inherits="KhaoSatHSSV.Control.ucQuestion" %>
 <%@ Register src="ucChooseLevel.ascx" tagname="ucChooseLevel" tagprefix="uc1" %>
 <div style="border: 1px solid black;overflow: hidden;padding-left: 10px">
<asp:Repeater ID="rptQuestion" runat="server">
    <ItemTemplate>
        <div class="question">
         <p><span style="font-weight: bold"><%# Container.ItemIndex+1 %>.</span> <%#Eval("QuestionName") %> 
          <asp:HiddenField ID="hdGroupId" runat="server" Value='<%# GroupId %>' />
          <asp:HiddenField ID="hdQuestionId" runat="server" Value='<%#Eval("Id") %>' />
         </p>
          <uc1:ucChooseLevel ID="ucChooseLevel1" runat="server" QuestionId='<%#Eval("Id") %>' />
          </div>
    </ItemTemplate>
</asp:Repeater>
</div>

