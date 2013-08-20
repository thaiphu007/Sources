<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="DSV.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpl1" runat="server">
    <div id="maincontent" rel='scrollcontent'>
    <div class="content" style="width: 720px">
        <table width="100%" border="1">
            <tr>
                <td colspan="2" style="height: 30px;" valign="middle">
                    Category    
                </td>
            </tr>
            <tr>
                <td rowspan="2" style="width: 150px;height: 120px">
                    image
                </td>
                <td style="height: 24px" valign="middle">
                    Title    
                </td>
            </tr>
            <tr>
                <td>Summary</td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>
