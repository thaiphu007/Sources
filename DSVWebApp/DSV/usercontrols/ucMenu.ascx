<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_ucMenu" Codebehind="ucMenu.ascx.cs" %>
<%@ Register src="SubMenu.ascx" tagname="SubMenu" tagprefix="uc1" %>
            <ul class="item">
                <li><a href='<%= Contants.SITE_NAME %>'>Trang chủ</a></li>
                <asp:Repeater ID="rptMenu" runat="server" 
                    onitemdatabound="rptMenu_ItemDataBound">
                    <ItemTemplate><li class="active"><a href='<%# Contants.SITE_NAME + Commons.RemoveSpecialCharacters(Eval("CateName").ToString()) %>/<%# Eval("Id") %>'><%# Eval("CateName") %></a><uc1:SubMenu ID="submenu" runat="server" />
                    </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>