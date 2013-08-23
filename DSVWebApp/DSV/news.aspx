<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="DSV.news" %>
<%@ Register src="usercontrols/ucNews.ascx" tagname="ucNews" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpl1" runat="server">
    <div id="maincontent">
    <div class="content news">
        <uc1:ucNews ID="ucNews1" runat="server" />
    </div>
    </div>
</asp:Content>
