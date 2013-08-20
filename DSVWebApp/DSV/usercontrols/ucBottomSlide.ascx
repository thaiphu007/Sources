<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_ucBottomSlide" Codebehind="ucBottomSlide.ascx.cs" %>
 <div class="jimgMenu"> 		
        <ul id="project" >
            <asp:Repeater ID="rptSlide" runat="server">
            <ItemTemplate><li><a style="background: url(<%# Container.DataItem %>);" href="javascript:void(0)"></a></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
</div>