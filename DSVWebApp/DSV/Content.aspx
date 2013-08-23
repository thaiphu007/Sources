<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" Inherits="Content" EnableViewState="false" Codebehind="Content.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="http://static.ak.fbcdn.net/connect.php/js/FB.Share" type="text/javascript"></script>
    <script src="http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php" type="text/javascript"></script>
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
        <div id="share">
            <a name="sharebutton" type="button" href="http://www.facebook.com/sharer.php?u=<%= Contants.SITE_NAME %><%=Request.RawUrl.Substring(1,Request.RawUrl.Length-1) %>"><img src="http://st.f2.vnecdn.net/i/v36/icons/facebook.gif" align="bottom"/> Share</a>  
     </div>

    </div>
    
</div>
</asp:Content>

