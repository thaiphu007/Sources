<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenu.ascx.cs" Inherits="usercontrols_ucMenu" %>
<%@ Register src="SubMenu.ascx" tagname="SubMenu" tagprefix="uc1" %>
            <ul class="item">
                <li><a href='<%= Contants.SITE_NAME %>trang-chu'>Trang chủ</a></li>
                <asp:Repeater ID="rptMenu" runat="server" 
                    onitemdatabound="rptMenu_ItemDataBound">
                    <ItemTemplate><li class="active"><a href='<%# Contants.SITE_NAME + Commons.RemoveSpecialCharacters(Eval("CateName").ToString()) %>/<%# Eval("Id") %>'><%# Eval("CateName") %></a><uc1:SubMenu ID="submenu" runat="server" />
                    </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>