<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSubNews.ascx.cs" Inherits="DSV.usercontrols.ucSubNews" %>
 <div class="sub">
                            <ul class="subitem">
                                <asp:Repeater ID="rptSub" runat="server">
                                    <ItemTemplate><li><a href="/<%# Eval("Id")%>/tintuc.htm"><%# Eval("CategoryName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                             </ul>
                        </div>