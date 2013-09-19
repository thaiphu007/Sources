<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGroup.ascx.cs" Inherits="KhaoSatHSSV.Control.ucGroup" %>
<%@ Register src="ucQuestion.ascx" tagname="ucQuestion" tagprefix="uc1" %>
<asp:Repeater ID="rptGroup" runat="server" OnItemDataBound="rptGroup_ItemDatabound">
    <ItemTemplate>
        <div class="group">
        <p>
        <span class="title"><%# Eval("GroupName") %>: <%#Eval("Description") %> </span>
            <asp:HiddenField ID="hdGroupId" runat="server" Value='<%#Eval("Id") %>' />
        <uc1:ucQuestion ID="GroupQuestion" runat="server" GroupId='<%#Eval("Id") %>' />
        </p>
        </div>
    </ItemTemplate>
</asp:Repeater>

