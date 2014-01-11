<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="SelectDepartment.aspx.cs" Inherits="KhaoSatHSSV.SelectDepartment" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table>
        
        <tr>
            <td>
                <asp:Repeater ID="rptNhom" runat="server" OnItemDataBound="rptNhom_ItemDataBound">
                    <ItemTemplate>
                        
                       <div style="width: 100%;">
                           <p style="font-weight: bold">+ Nhóm <%# Container.DataItem %></p>
                        
                        <asp:Repeater ID="rptNganh" runat="server">
                            <ItemTemplate>
                               <div style="float: left;width: 200px;padding-right: 10px;padding-bottom: 3px">
                                   - <%# Container.DataItem %>
                               </div>
                               
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="clear: both;"></div>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td> 
                <asp:Button ID="btnSelect" runat="server" Text="Tư Vấn Chọn Ngành" OnClick="btnSelect_Click" /></td>
        </tr>
    </table>
</asp:Content>
