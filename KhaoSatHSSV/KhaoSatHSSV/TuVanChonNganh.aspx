<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="TuVanChonNganh.aspx.cs" Inherits="KhaoSatHSSV.TuVanChonNganh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <table runat="server" id="tbListNganh" Visible="False">
        <tr>
           <td style="width: 100%">
               Danh sách ngành bạn có thể chọn
                <div style="width: 100%;">
                        <asp:Repeater ID="rptNganh" runat="server">
                            <ItemTemplate>
                              
                                     <div style="float: left;width: 200px;padding-right: 10px;padding-bottom: 3px">
                                         <input id="Checkbox1" type="radio" name="nganh" />  - <%# Eval("TN") %>
                                
                               </div>
                            </ItemTemplate>
                        </asp:Repeater>
                </div>
           </td>
        </tr>
    </table>
 <div class="ct_item" id="survey5">
    III. Đánh giá năng lực dựa vào kết quả học tập:
</div>
<div class="ct_subitem" id="survey6">
   
   Bạn hãy chọn vào khối thi mà bạn đã tham gia vào kỳ thi tuyển sinh ĐH-CĐ và bạn căn cứ vào học bạ lớp 10, 11, 12 điền điểm trung bình vào bảng bên dưới
   
   
    <p>
   1.	Khối thi:  
        <asp:DropDownList ID="drpKhoiThi" runat="server">
        </asp:DropDownList>
   </p>
   <p>
       2.	Điền điểm trung bình cả năm của lớp 10, 11, 12 vào các ô tương ứng. Nếu chưa có điểm của năm, lấy điểm trung bình của học kỳ trước đó. 
			
   </p>

   <table cellpadding="3" cellspacing="0" class="tbl_Average">
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">Điểm trung bình
(căn cứ vào học bạ lớp 10, 11, 12)

                </td>
        </tr>
        <tr>
            <td>
                Môn học</td>
            <td>
                Lớp 10</td>
            <td>
                Lớp 11</td>
            <td>
                Lớp 12</td>
        </tr>
        <tr>
            <td>
                Toán</td>
            <td>
                 <asp:TextBox ID="txtToan10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtToan11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtToan12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Vật Lý</td>
            <td>
                 <asp:TextBox ID="txtVatLy10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtVatLy11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtVatLy12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Hóa Học</td>
             <td>
                 <asp:TextBox ID="txtHoaHoc10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtHoaHoc11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtHoaHoc12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Văn</td>
            <td>
                 <asp:TextBox ID="txtVan10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtVan11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtVan12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Lịch Sử</td>
            <td>
                 <asp:TextBox ID="txtLichSu10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtLichSu11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtLichSu12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Địa Lý</td>
             <td>
                 <asp:TextBox ID="txtDiaLy10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtDiaLy11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtDiaLy12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               Ngoại Ngữ</td>
             <td>
                 <asp:TextBox ID="txtTiengAnh10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtTiengAnh11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtTiengAnh12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Sinh</td>
             <td>
                 <asp:TextBox ID="txtSinh10" runat="server" Text="0"></asp:TextBox></td>
            <td>
                 <asp:TextBox ID="txtSinh11" runat="server" Text="0"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtSinh12" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
    </table>
    
    <p>
       3.	Ước đoán khả năng làm bài thi tuyển sinh của khối thi tương ứng bằng 1 trong 2 cách bên dưới và điền kết quả vào ô kế bên 
        <asp:TextBox ID="txtDiemDuDoan" runat="server"></asp:TextBox> (chỉ nhập 0,1 đến 1)
			<br/>
            Cách 1: Tự đánh giá khả năng sẽ làm được bài thi tuyển sinh được bao nhieu điểm?
            <br/>
            Cách 2: Thử giải đề thi của năm gần nhất, rồi lấy tổng điểm của 3 môn ở 2 năm chia cho 60.
   </p>
   <p>
       Điểm dao động (+/-)<br/>
       <asp:RadioButton ID="radone" runat="server" GroupName="point" Text="1" />
       <asp:RadioButton ID="radtwo" runat="server" GroupName="point" Text="2" />
       <asp:RadioButton ID="radThree" runat="server" GroupName="point" Text="3" />
   </p>
   <p align="center">
       <asp:Button ID="btnFinish" runat="server" Text="Hoàn Tất" OnClick="btnFinish_click" />
   </p>
 </div>
</asp:Content>
