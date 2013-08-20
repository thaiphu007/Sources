<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_ucTopSlide" Codebehind="ucTopSlide.ascx.cs" %>
<div id="wowslider-container1">
    <div class="ws_images"><ul>
        <asp:Repeater ID="rptSlide" runat="server">
        <ItemTemplate><li><a href="javascript:void(0)"><img src="<%# Container.DataItem %>" alt="" /></a></li>
        </ItemTemplate>
        </asp:Repeater>       
    </ul></div>
</div>
<script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/js/wowslider.js"></script>
<script type="text/javascript" src="<%= Contants.SITE_NAME %>scripts/js/script.js"></script>