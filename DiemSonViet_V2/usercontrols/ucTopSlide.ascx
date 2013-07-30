<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTopSlide.ascx.cs" Inherits="usercontrols_ucTopSlide" %>
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