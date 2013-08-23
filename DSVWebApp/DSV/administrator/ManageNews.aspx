<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" Inherits="DSV.administrator.ManageNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAdd" runat="server" Text="Thêm" onclick="btnAdd_Click" /> 
    <asp:Button ID="btnDelete" runat="server" Text="Xóa" onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />    
<table id="list">
    <tr>
        <th><input type="checkbox" value="All" name="ckAll" id="ckAll" onchange="checkAll(this.checked);" title="Chon Tat Ca" /></th>
        <th>Tiêu đề</th>
        <th>Chuyên mục</th>
        <th>Trạng thái</th>
        <th>Ngày viết</th>
        <th>Thứ tự</th>
        <th></th>
    </tr>
    
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr class="item">
                <td class="textcenter"><input type="checkbox" onchange="checkItem();" value='<%#Eval("Id") %>' name='ckselect'  title="Chon" /></td>
                <td><%# Eval("ArTitle") %></td>
                <td><%# Eval("Category_New") != null ? Eval("Category_New.CategoryName") : "N/A"%></td>
                <td><%# Convert.ToBoolean(Eval("IsPublished"))?"Đăng":"Ẩn" %></td>
                <td><%# Eval("CreateDated","{0:dd/MM/yyyy}") %></td>
                
                <td class="textcenter"><%# Eval("DisplayOrder")%></td>
                <td><a href='AddNews.aspx?act=edit&id=<%#Eval("Id") %>'> Sửa</a></td>
            </tr>
        </ItemTemplate>        
        <AlternatingItemTemplate>
            <tr class="alter">
                <td class="textcenter"><input type="checkbox" onchange="checkItem();" value='<%#Eval("Id") %>' name='ckselect'  title="Chon" /></td>
                <td><%# Eval("ArTitle") %></td>
                <td><%# Eval("Category_New") != null ? Eval("Category_New.CategoryName") : "N/A"%></td>
                <td><%# Convert.ToBoolean(Eval("IsPublished"))?"Đăng":"Ẩn" %></td>
                <td><%# Eval("CreateDated","{0:dd/MM/yyyy}") %></td>
                <td class="textcenter"><%# Eval("DisplayOrder")%></td>
                <td><a href='AddNews.aspx?act=edit&id=<%#Eval("Id") %>'> Sửa</a></td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
    
</table>
<asp:Button ID="Button1" runat="server" Text="Thêm" onclick="btnAdd_Click" /> 
    <asp:Button ID="Button2" runat="server" Text="Xóa" 
        onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />
</asp:Content>
