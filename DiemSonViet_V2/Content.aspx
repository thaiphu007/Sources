<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Content" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/jquery.mousewheel.min.js"></script>
<script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/slickcustomscroll.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("div[rel='scrollcontent']").customscroll({ direction: "vertical" });
        if ($('.scrollcontent-content').height() >= 748) {
            $('.scrollcontent-bar').show();            
        }
        else {
            $('.scrollcontent-bar').hide();
        }
    });    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpl1" Runat="Server">
<div id="maincontent" rel='scrollcontent'>    
    <div class="content">
        <asp:Literal ID="liContent" runat="server"></asp:Literal>
       </div>
</div>
</asp:Content>

