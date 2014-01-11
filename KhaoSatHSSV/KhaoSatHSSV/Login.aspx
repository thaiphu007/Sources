<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KhaoSatHSSV.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
         <tr>
            <td>
               <asp:HyperLink ID="hpRegister" NavigateUrl="/Register.aspx" runat="server">Đăng Ký</asp:HyperLink>
            <td>
              
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td style="font-size: 24px">
               <strong>Đăng Nhập</strong> 
            </td>
        </tr>
        <tr>
            <td>
                Tên Đăng Nhập:
            </td>
            <td>
                <asp:TextBox ID="txtTenDangNhap" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Mật Khẩu:
            </td>
            <td>
                 <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDangNhap" runat="server" Text="Đăng Nhập" OnClick="btn_Click" />
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" ForeColor="red" Text=""></asp:Label>
            </td>
        </tr>
     
       
    </table>
</asp:Content>
