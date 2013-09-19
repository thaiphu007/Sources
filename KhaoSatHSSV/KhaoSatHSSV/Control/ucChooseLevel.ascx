<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChooseLevel.ascx.cs" Inherits="KhaoSatHSSV.Control.ucChooseLevel" %>
<p class="chooselevel">
            <asp:RadioButton ID="radMuc1" runat="server" Checked="True" GroupName="ChooseLevel" Text="Mức 1" />
            <asp:RadioButton ID="radMuc2" runat="server" GroupName="ChooseLevel" Text="Mức 2" />
            <asp:RadioButton ID="radMuc3" runat="server" GroupName="ChooseLevel" Text="Mức 3" />
            <asp:RadioButton ID="radMuc4" runat="server" GroupName="ChooseLevel" Text="Mức 4" />
            <asp:RadioButton ID="radMuc5" runat="server" GroupName="ChooseLevel" Text="Mức 5" />
            <asp:HiddenField ID="hdQuestionId" runat="server" Value='<%# QuestionId %>' />
 </p>