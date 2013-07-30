<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubMenu.ascx.cs" Inherits="usercontrols_SubMenu" %>
                        <div class="sub">
                            <ul class="subitem">
                                <asp:Repeater ID="rptSub" runat="server">
                                    <ItemTemplate><li><a href="<%# Contants.SITE_NAME + PareantCateName %>/<%# Commons.RemoveSpecialCharacters(Eval("CateName").ToString()) %>/<%# Eval("Id") %>"><%# Eval("CateName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                             </ul>
                        </div>