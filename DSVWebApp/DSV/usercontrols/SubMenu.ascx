<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_SubMenu" Codebehind="SubMenu.ascx.cs" %>
                        <div class="sub">
                            <ul class="subitem">
                                <asp:Repeater ID="rptSub" runat="server">
                                    <ItemTemplate><li><a href="<%# Contants.SITE_NAME + PareantCateName %>/<%# Commons.RemoveSpecialCharacters(Eval("CateName").ToString()) %>/<%# Eval("Id") %>"><%# Eval("CateName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                             </ul>
                        </div>