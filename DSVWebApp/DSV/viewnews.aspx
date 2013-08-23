<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" CodeBehind="viewnews.aspx.cs" Inherits="DSV.viewnews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
       <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpl1" runat="server">
    <div id="maincontent" rel='scrollcontent'>
    <div class="content">
        <div style="padding-bottom: 10px">
            <h1 class="viewnews-title"><asp:Literal ID="liTitle" runat="server"></asp:Literal></h1>
         </div>
        <div style="padding-bottom: 10px">
            <div class="fb-like" data-href="<%=Request.Url.ToString() %>" data-width="450" data-layout="button_count" data-show-faces="true" data-send="true"></div>
        </div>
        <asp:Literal ID="liContent" runat="server"></asp:Literal>
        
     

    </div>
    
</div>
</asp:Content>
