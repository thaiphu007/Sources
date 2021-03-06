﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="addCategoryNews.aspx.cs" Inherits="DSV.administrator.addCategoryNews" %>
<%@ Register src="usercontrols/ucStatus.ascx" tagname="ucStatus" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucStatus ID="ucStatus1" runat="server" />

    <asp:HiddenField ID="hdID" runat="server" Value="" />
    <asp:Label ID="lblError" runat="server" Text="" CssClass="redmark"></asp:Label>
<table id="Add">
    <tr>
        <td style="width:100px;">Tên Danh Mục <span class="redmark">*</span></td>
        <td>
            <asp:TextBox ID="txtCateName" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>    
    <tr>
        <td>Thứ Tự <span class="redmark">*</span></td>
        <td><asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="3" Width="50px" Text="0"></asp:TextBox></td>        
    </tr>
    <tr>
        <td>Ẩn</td>
        <td>
            <asp:CheckBox ID="chkHidden" runat="server" /></td>        
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnSave" runat="server" Text="Lưu" onclick="btnSave_Click" /> <asp:Button ID="btnContinue" runat="server" Text="Lưu và tiếp tục" onclick="btnSave_Click" /> 
            <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnSave_Click" /></td>        
    </tr>
</table>
    
</asp:Content>
