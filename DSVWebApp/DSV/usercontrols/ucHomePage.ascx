<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_ucHomePage" Codebehind="ucHomePage.ascx.cs" %>
<asp:Repeater ID="rptHomePage" runat="server">
<ItemTemplate>
  <div class="block">
            <div class="hd">
                <div class="hdicon">
                    <a href="ViewContent.aspx?cid=<%#Eval("Id")%> "><img src="uploads/icons/<%#Eval("Icon") %>" alt="" style="width:48px;height:37px;border:0px" /></a></div>
                <div class="hdtitle">
                    <a href="ViewContent.aspx?cid=<%#Eval("Id")%> "><%#Eval("ContentTitle")%></a>
                </div>
            </div>
            <div class="ct">
                <%#Eval("ShortContent")%>             
                <div class="viewdetails">
                    <a href="ViewContent.aspx?cid=<%#Eval("Id")%> ">Xem Thêm >></a></div>
            </div>
  </div>
  <%# Container.ItemIndex%2!=0?"<div class='clr'></div><div class='baseline'></div><div class='clr'></div>":""
   %>
       
</ItemTemplate>
</asp:Repeater>
