<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNews.ascx.cs" Inherits="DSV.usercontrols.ucNews" %>
<table width="100%" border="0">
    <asp:Repeater ID="rptNews" runat="server">
        <ItemTemplate>
            <tr style="display: <%# string.IsNullOrEmpty(Request.QueryString["cid"])?"": (Container.ItemIndex>0?"none":"")%>">
                <td colspan="2" valign="middle" class="news-header" >
                   <a href="/<%# Eval("CateId") %>/tintuc.htm"><%# Eval("Category_New.CategoryName") %>    </a> 
                </td>
            </tr>
            <tr class="news-rowline">
                <td rowspan="3" valign="middle" class="news-icon">
                    <img src="<%#Eval("ImageDefault").ToString().Contains("://")?Eval("ImageDefault"):"/uploads/images/"+Eval("ImageDefault") %>" />
                </td>
                <td class="news-title" valign="middle">
                    <a href="/<%# Eval("Id") %>/xemtin.htm"> <%#Eval("ArTitle") %></a>
                </td>
            </tr>
            <tr>
                <td class="news-date">Ngày đăng: <%#Eval("CreateDated","{0:dd-MM-yyyy}") %></td>
            </tr>
            <tr class="news-rowline">
                <td><%#Eval("ArSummary") %><a href="/<%# Eval("Id") %>/xemtin.htm"> Chi tiết</a></td>
            </tr>
            </ItemTemplate>
    </asp:Repeater>
</table>
