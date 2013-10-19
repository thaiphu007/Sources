<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="KhaoSatHSSV.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p>
        <asp:Literal ID="liFullName" runat="server"></asp:Literal>
    </p>
     <p>
       Nhóm R: <asp:Literal ID="liR" runat="server"></asp:Literal> điểm
    </p>
    <p>
       Nhóm I: <asp:Literal ID="liI" runat="server"></asp:Literal> điểm
    </p>
    <p>
       Nhóm A:  <asp:Literal ID="liA" runat="server"></asp:Literal> điểm
    </p>
    <p>
       Nhóm E:  <asp:Literal ID="liE" runat="server"></asp:Literal> điểm
    </p>
    <p>
       Nhóm S: <asp:Literal ID="liS" runat="server"></asp:Literal> điểm
    </p>
    <p>
       Nhóm C: <asp:Literal ID="liC" runat="server"></asp:Literal> điểm
    </p>
    <p>
      Bạn đã hoàn thành khảo sát thông tin. 
        </p>
        <p>
            Kết Quả của bạn:
        </p>
         <p>
        <asp:Literal ID="liNhom1" runat="server"></asp:Literal>
        <br/>
        <asp:Literal ID="liNhom2" runat="server"></asp:Literal>
    </p>
    <p>
           <asp:Label ID="liMessage" ForeColor="Red" runat="server"></asp:Label>
    </p>
        <p>
            <asp:Button ID="btnPrevious" runat="server" Text="Thực hiện lại" Visible="False" OnClick="btn_Previous" />
             <asp:Button ID="btnContinue" runat="server" Text="Tiếp Tục" OnClick="btn_Continue" />
            </p>
</asp:Content>
