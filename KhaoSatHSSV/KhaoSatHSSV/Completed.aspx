<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Completed.aspx.cs" Inherits="KhaoSatHSSV.Completed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table >
        <tr>
           <td style="width: 100px">
               Danh sách Trường đào tạo Phù hợp vơi Ngành Của Bạn
                <div style="width: 100%;">
                        <asp:Repeater ID="rptTruong" runat="server">
                            <ItemTemplate>
                               <div style="width: 400px;padding-right: 10px;padding-bottom: 3px">
                                   - <%# Eval("TenTruong") %>
                               </div>
                            </ItemTemplate>
                        </asp:Repeater>
                </div>
           </td>
        </tr>
    </table>
</asp:Content>
