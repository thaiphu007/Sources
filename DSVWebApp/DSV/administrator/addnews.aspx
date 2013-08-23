<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="addnews.aspx.cs" Inherits="DSV.administrator.addnews" %>
<%@ Register src="usercontrols/ucStatus.ascx" tagname="ucStatus" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc1:ucStatus ID="ucStatus1" runat="server" />
    <asp:HiddenField ID="hdID" runat="server" Value="" />
    <asp:HiddenField ID="hdCateID" runat="server" Value="" />
    <asp:Label ID="lblError" runat="server" Text="" CssClass="redmark"></asp:Label>
<table id="Add">
    <tr>
        <td> Chuyên mục <span class="redmark">*</span></td>
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td >Tiêu đề <span class="redmark">*</span></td>
        <td ><asp:TextBox ID="txtTitle" runat="server" MaxLength="150" Width="600"></asp:TextBox>

        </td>
    </tr> 
    <tr>
        <td>Hình Ảnh Đại Diện</td>
        <td>
            <asp:TextBox ID="txturlIcon" runat="server" MaxLength="150">
            </asp:TextBox>(Nhập đường dẫn hình or chọn file từ máy tính)<br/> <asp:FileUpload ID="fUpiCon" runat="server" /> <br/> <asp:Image ID="imgIcon" Width="100px" runat="server" />
         </td>
        
    </tr>   
    <tr>
        <td colspan="2">
        Nội dung ngắn <span class="redmark">*</span>
            <FCKeditorV2:FCKeditor ID="txtShortContent" runat="server" AutoDetectLanguage="false" Height="200" ToolbarStartExpanded="false"
                                Width="800px" /></td>
    </tr>
    <tr>
        <td colspan="2">
        Nội dung<br />
        <FCKeditorV2:FCKeditor ID="txtBody" runat="server" AutoDetectLanguage="false" Height="400"
                                Width="800px" />
        </td>
    </tr>        
    
    <tr>
        <td>Thứ Tự <span class="redmark">*</span></td>
        <td><asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="3" Width="50px" Text="0"></asp:TextBox></td>        
    </tr>
     <tr>
        <td>Đăng</td>
        <td>
            <asp:CheckBox ID="chkPublish" runat="server" />
        </td>        
    </tr>
     <tr>
        <td>SEO tiêu đề (max lenth:500)</td>
        <td>
            <asp:TextBox ID="txtMetaTitle" runat="server" MaxLength="500" Width="600px"></asp:TextBox>
        </td>        
    </tr>
    <tr>
        <td>SEO từ Khóa (max lenth:500)</td>
        <td>
            <asp:TextBox ID="txtKeywords" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
        </td>        
    </tr>
     <tr>
        <td>SEO mô tả (max lenth:500)</td>
        <td>
            <asp:TextBox ID="txtDescriptions" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
        </td>        
    </tr>
   
    <tr>
        <td></td>
        <td><asp:Button ID="btnSave" runat="server" Text="Lưu" onclick="btnSave_Click" /> <asp:Button ID="btnContinue" runat="server" Text="Lưu và tiếp tục" onclick="btnSave_Click" /> 
           <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnSave_Click" /></td>        
    </tr>
    
</table>
</asp:Content>
