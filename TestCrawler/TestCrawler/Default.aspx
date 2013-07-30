<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestCrawler.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
        <asp:Button ID="btnPause" runat="server" Text="Pause" OnClick="btnGo_Click" />
        <asp:Button ID="btnStop" runat="server" Text="Stop" OnClick="btnGo_Click" />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
