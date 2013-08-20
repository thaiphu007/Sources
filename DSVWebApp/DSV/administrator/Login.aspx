<%@ Page Language="C#" AutoEventWireup="true" Inherits="administrator_Login" Codebehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:300px;">
    <tr>
    <td style="width:90px"></td>
    <td><%=ErrorMessage %></td>    
    </tr>
    <tr>
    <td>User Name </td>
    <td>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>    
    </tr>
    <tr>
    <td>Password</td>
    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>    
    </tr>
    <tr>
    <td>Mã Xác Nhận</td>
    <td><asp:TextBox ID="txtCode" runat="server" AutoCompleteType="Disabled"></asp:TextBox></td>    
    </tr>
      <tr>
    <td></td>
    <td>
        <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" 
            onclick="btnLogin_Click" /></td>    
    </tr>
    </table>
    </form>
</body>
</html>
