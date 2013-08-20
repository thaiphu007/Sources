<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/AdminMasterPage.master" AutoEventWireup="true" Inherits="administrator_AddContent" ValidateRequest="false" Codebehind="AddContent.aspx.cs" %>
<%@ Register src="usercontrols/ucStatus.ascx" tagname="ucStatus" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <uc1:ucStatus ID="ucStatus1" runat="server" />
    <asp:HiddenField ID="hdID" runat="server" Value="" />
    <asp:HiddenField ID="hdCateID" runat="server" Value="" />
    <asp:Label ID="lblError" runat="server" Text="" CssClass="redmark"></asp:Label>
<table id="Add">

    <tr style="display:none">
        <td style="width:130px;">Tên nội dung <span class="redmark">*</span></td>
        <td>
            <asp:TextBox ID="txtContentName" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>    
    
    <tr>
        <td >Tiêu đề <span class="redmark">*</span></td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="50"></asp:TextBox></td>
    </tr>    
    <tr>
        
        <td colspan="2">
        Nội dung ngắn <span class="redmark">*</span>
            <FCKeditorV2:FCKeditor ID="txtShortContent" runat="server" AutoDetectLanguage="false" Height="100" ToolbarStartExpanded="false"
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
        <td  >Icon</td>
        <td>
            <asp:Image ID="imgIcon" Width="20px" runat="server" />
            <asp:FileUpload ID="fUpiCon" runat="server" />
            
         </td>
        
    </tr>
    <tr style="display:none">
        <td>Đặt ở trang chủ</td>
        <td>
            <asp:CheckBox ID="ckHomePage" runat="server" />
        </td>        
    </tr>
     <tr style="display:none">
        <td>Ẩn</td>
        <td>
            <asp:CheckBox ID="chkHidden" runat="server" />
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
            <asp:Button ID="btnDelete" runat="server" Visible="false" Text="Delete" onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure?')" /> <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnSave_Click" /></td>        
    </tr>
    
</table>

</asp:Content>

