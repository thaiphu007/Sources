<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/AdminMasterPage.master" AutoEventWireup="true" Inherits="administrator_Default" Codebehind="Default.aspx.cs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Button ID="btnAdd" runat="server" Text="Thêm" onclick="btnAdd_Click" /> 
    <asp:Button ID="btnDelete" runat="server" Text="Xóa" 
        onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />    
<table id="list">
    <tr>
        <th><input type="checkbox" value="All" name="ckAll" id="ckAll" onchange="checkAll(this.checked);" title="Chon Tat Ca" /></th>
        <th>Tên Danh mục</th>
        <th>Thứ Tự</th>
        <th>Danh Mục Cha</th>
        <th>Hiện thị</th>
        <th></th>
    </tr>
    
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr class="item">
                <td class="textcenter"><input type="checkbox" onchange="checkItem();" value='<%#Eval("Id") %>' name='ckselect'  title="Chon" /></td>
                <td><%# Eval("CateName") %></td>
                <td class="textcenter"><%# Eval("DisplayOrder")%></td>
                <td><%# Eval("tbl_Category1") != null ? Eval("tbl_Category1.CateName") : "N/A"%></td>
                <td><%# Eval("Hidden") == null ? "Hiện" : Convert.ToBoolean(Eval("Hidden"))?"Ẩn":"Hiện" %></td>
                <td><a href='AddCategory.aspx?act=edit&id=<%#Eval("Id") %>' > Sửa </a> | <a href='AddContent.aspx?cid=<%# Eval("Id")%>'> Nội dung </a> </td>
            </tr>
        </ItemTemplate>        
        <AlternatingItemTemplate>
            <tr class="alter">
                <td class="textcenter"><input type="checkbox" onchange="checkItem();" value='<%#Eval("Id") %>' name='ckselect' title="Chon" /></td>
                <td><%# Eval("CateName") %></td>
                <td class="textcenter"><%# Eval("DisplayOrder")%></td>
                <td><%# Eval("tbl_Category1") != null ? Eval("tbl_Category1.CateName") : "N/A"%></td>
                <td><%# Eval("Hidden") == null ? "Hiện" : Convert.ToBoolean(Eval("Hidden"))?"Ẩn":"Hiện" %></td>
                <td><a href='AddCategory.aspx?act=edit&id=<%#Eval("Id") %>' > Sửa </a> | <a href='AddContent.aspx?cid=<%# Eval("Id")%>' > Nội dung </a></td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
    
</table>
<asp:Button ID="Button1" runat="server" Text="Thêm" onclick="btnAdd_Click" /> 
    <asp:Button ID="Button2" runat="server" Text="Xóa" 
        onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />

</asp:Content>

