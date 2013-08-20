<%@ Page Title="" Language="C#" MasterPageFile="~/master/MasterPage.master" AutoEventWireup="true" EnableViewState="false" Inherits="_Default" Codebehind="Default.aspx.cs" %>
<%@ Register src="usercontrols/ucTopSlide.ascx" tagname="ucTopSlide" tagprefix="uc1" %>
<%@ Register src="usercontrols/ucBottomSlide.ascx" tagname="ucBottomSlide" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/js/jquery.kwicks-1.5.1.pack.js"></script>
    <script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/js/hoverIntent.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.jimgMenu ul').kwicks({ max: 300, duration: 400, easing: 'easeOutQuad' });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpl1" Runat="Server">
<div class="content-head">
    <a name="fb_share" type="button" href="http://www.facebook.com/sharer.php">Share</a>
    <div id="rtop">    
        <uc1:uctopslide ID="ucTopSlide1" runat="server" />    
    </div>
</div>
<div style="width:100%;height:10px;width:730px;background-color:#848484;margin:0 auto"></div>
    <div id="rmiddle">
        <div id="slides">
            <uc2:ucbottomslide ID="ucBottomSlide1" runat="server" />
        </div>
    </div>
    <div id="rbottom">
        <img src="<%=Contants.SITE_NAME %>images/footer_main_contact.png" alt="Lien he" /></div>
</asp:Content>