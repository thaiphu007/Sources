<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="KhaoSatHSSV.ViewResult" %>
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
    </p><p>
      Bạn đã hoàn thành khảo sát thông tin. Cảm ơn bạn đã tham gia Khảo sát. Chúc bạn một ngày vui vẻ.
        </p>
</asp:Content>
