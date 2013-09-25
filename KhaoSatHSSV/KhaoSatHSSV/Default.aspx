<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KhaoSatHSSV.Default" %>
<%@ Register src="Control/ucGroup.ascx" tagname="ucGroup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        HideSurvey();
        $("#survey1").show();
    });

    function showSurvey(id) {
        HideSurvey();
        if (id == "survey5")
            $("#survey6").show();
        $("#"+id).show();
        
    }
    function HideSurvey() {
        $("#survey1").hide();
        $("#survey2").hide();
        $("#survey3").hide();
        $("#survey4").hide();
        $("#survey5").hide();
        $("#survey6").hide();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="ct_Header">PHIẾU KHẢO SÁT THÔNG TIN
    </div>
    <div class="ct_title">
        Xin chào bạn, mình đang thực hiện một đề tài Nghiên cứu khoa học về “Ứng dụng Khai phá dữ liệu chọn ngành nghề cho học sinh THPT”. Hiện nay, mình

cần khảo sát một số thông tin liên quan đến sở thích, ước muốn, tính cách, điểm TB các năm học 10, 11, 12 và quyết định về việc chọn ngành nghề của bạn. Các 

câu trả lời của các bạn là cơ sở để mình đánh giá kết quả thực nghiệm của đề tài. Mình rất mong nhận được sự giúp đỡ của bạn bằng cách trả lời các câu hỏi dưới 

đây. Xin chân thành cám ơn.
    </div>
    <div class="ct_item">
    I. Thông tin cá nhân
</div>
    <table class="style1" cellpadding="0" cellspacing="0" >
    <tr>
        <td width="150px">
            Họ Tên: (<span style="color: red">*</span>)</td>
        <td width="350px">
            <asp:TextBox ID="txtFullName" runat="server" Width="330px" MaxLength="50"></asp:TextBox>
        </td>
        <td width="130px">
            Phái:</td>
        <td width="200px">
            <asp:RadioButton ID="radNam" runat="server" GroupName="phai" Checked="True" Text="Nam" />
            <asp:RadioButton ID="radNu" runat="server" GroupName="phai" Text="Nữ" />
        </td>
        <td width="100px">
            Ngày Sinh:</td>
        <td>
            <telerik:RadDatePicker ID="txtBirthDate" runat="server" Skin="Default" Width="100px">
                <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server">
                </DateInput>
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            Địa chỉ:&nbsp;</td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Width="330px" MaxLength="250"></asp:TextBox>
        </td>
        <td>
            Nơi Sinh:</td>
        <td>
            <asp:DropDownList ID="ddlWhereBirth" runat="server" Width="190px">
            </asp:DropDownList>
        </td>
        <td>
            Điện Thoại</td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Sở Thích Bản Thân:</td>
        <td>
            <asp:TextBox ID="txtFavorite" runat="server" Width="330px" MaxLength="250"></asp:TextBox>
        </td>
        <td>
            Học THPT tại</td>
        <td colspan="3">
            <asp:DropDownList ID="ddlProvince" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedChanged">
            </asp:DropDownList>
      
             Trường:
            <asp:DropDownList ID="ddlTruong" runat="server" Width="185px">
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td>
            Thích Học Ngành Gì?</td>
        <td>
            <asp:TextBox ID="txtDepartment" runat="server" Width="330px" MaxLength="250"></asp:TextBox>
        </td>
        <td>
            Lý Do:</td>
        <td colspan="3">
            <asp:TextBox ID="txtReason" runat="server" Width="400px" MaxLength="250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Điểm Thi ĐH, CĐ:</td>
        <td valign="middle">
            <asp:TextBox ID="txtPointTest" runat="server" Width="20px" Text="0" MaxLength="2"></asp:TextBox>
        &nbsp; Trường Dự Thi:<asp:DropDownList ID="ddlDuThi" runat="server" Width="204px">
            </asp:DropDownList>
        </td>
        <td>
            Khối Thi:</td>
        <td colspan="3">
            <asp:CheckBox ID="chkBlockA" runat="server" Text="A" />
            <asp:CheckBox ID="chkBlockB" runat="server" Text="B" />
            <asp:CheckBox ID="chkBlockC" runat="server" Text="C" />
            <asp:CheckBox ID="chkBlockD" runat="server" Text="D" />
            <asp:CheckBox ID="chkBlockOrther" runat="server" />
            <asp:TextBox ID="txtBlockOrther" runat="server" Width="88px" MaxLength="2"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Trường Đang Học</td>
        <td>
            <asp:DropDownList ID="ddlDangHoc" runat="server" Width="334px">
            </asp:DropDownList>
        </td>
        <td>
            Phù Hợp:</td>
        <td colspan="3">
            <asp:RadioButton ID="radMatch" runat="server" Text="Có" Checked="True" />
&nbsp;<asp:RadioButton ID="radUnMatch" runat="server" Text="Không" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lý Do:<asp:TextBox ID="txtReason1" 
                runat="server" Width="205px" MaxLength="250" ></asp:TextBox>
        </td>
    </tr>
</table>
<div class="ct_item">
    II. Câu hỏi trắc nghiệm khám phá bản thân và sở thích nghề nghiệp
</div>
<div class="ct_subitem">
    Bạn vui lòng chọn đúng sở thích, năng lực, khả năng của mình và dùng mức độ bên dưới để đánh giá và cho điểm nhận định của mình:
    <div class="subitem_box">
        <p>
            <table cellpadding="5" cellspacing="0" width="600px">
                <tr>
                    <td style="width: 70px">
                        Mức độ 1: 
                    </td>
                    <td style="width: 300px">
                        <span>Chưa bao giờ đúng </span> 
                    </td>
                    <td style="width: 70px">
                        – tương ứng
                    </td>
                    <td style="width: 50px">
                        <span>0 điểm</span> 
                    </td>
                </tr>
                 <tr>
                    <td style="width: 70px">
                        Mức độ 2: 
                    </td>
                    <td style="width: 300px">
                        <span>Chỉ đúng một vài trường hợp </span> 
                    </td>
                    <td style="width: 70px">
                        – tương ứng
                    </td>
                    <td style="width: 50px">
                        <span>1 điểm</span> 
                    </td>
                </tr>
                 <tr>
                    <td style="width: 70px">
                        Mức độ 3: 
                    </td>
                    <td style="width: 300px">
                        <span>Chỉ đúng một nửa </span> 
                    </td>
                    <td style="width: 70px">
                        – tương ứng
                    </td>
                    <td style="width: 50px">
                        <span>3 điểm</span> 
                    </td>
                </tr>
                 <tr>
                    <td style="width: 70px">
                        Mức độ 4: 
                    </td>
                    <td style="width: 300px">
                        <span>Gần như là đúng trong hầu hết mọi trường hợp </span> 
                    </td>
                    <td style="width: 70px">
                        – tương ứng
                    </td>
                    <td style="width: 50px">
                        <span>4 điểm</span> 
                    </td>
                </tr>
                 <tr>
                    <td style="width: 70px">
                        Mức độ 5: 
                    </td>
                    <td style="width: 300px">
                        <span>Hoàn toàn đúng</span> 
                    </td>
                    <td style="width: 70px">
                        – tương ứng
                    </td>
                    <td style="width: 50px">
                        <span>5 điểm</span> 
                    </td>
                </tr>
            </table>
    </div>
</div>
<div class="ct_subitem" id="survey1">
    1. Câu hỏi trắc nghiệm khám phá bản thân và sở thích nghề nghiệp (Tiến sĩ tâm lý học John Holland)

<div class="ct_questions">
    <div class="item_questions">
    <uc1:ucGroup ID="ucGroup1" runat="server" QuestionType="1" />
    </div>
</div>
<input value="Next" type="button" id="btnext" class="btnNext" onclick="showSurvey('survey2')" />
</div>
<div class="ct_subitem" id="survey2">
    2. Bạn thích làm nghề gì? (Trắc nghiệm sở thích nghề nghiệp – ĐH Quốc gia Tp.HCM)

<div class="ct_questions">
    <div class="item_questions">
    <uc1:ucGroup ID="ucGroup2" runat="server" QuestionType="2" />
    </div>
</div>
<input value="Next" type="button" id="Button2" class="btnNext" onclick="showSurvey('survey3')" />
<input value="Back" type="button" id="Button8" class="btnNext" onclick="showSurvey('survey1')" />
</div>
<div class="ct_subitem" id="survey3">
    3. Bạn thường làm gì vào thời gian rảnh? (Trắc nghiệm sở thích nghề nghiệp – ĐH Quốc gia Tp.HCM)

<div class="ct_questions">
    <div class="item_questions">
    <uc1:ucGroup ID="ucGroup4" runat="server" QuestionType="3" />
    </div>
</div>
<input value="Next" type="button" id="Button3" class="btnNext" onclick="showSurvey('survey4')" />
<input value="Back" type="button" id="Button7" class="btnNext" onclick="showSurvey('survey2')" />
</div>
<div class="ct_subitem" id="survey4">
    4. Tính cách của bạn như thế nào? (Trắc nghiệm sở thích nghề nghiệp – ĐH Quốc gia Tp.HCM)

<div class="ct_questions">
    <div class="item_questions">
    <uc1:ucGroup ID="ucGroup3" runat="server" QuestionType="4" />
    </div>
</div>
<input value="Next" type="button" id="Button4" class="btnNext" onclick="showSurvey('survey5')" />
<input value="Back" type="button" id="Button6" class="btnNext" onclick="showSurvey('survey3')" />
</div>
<div class="ct_item" id="survey5">
    III. Đánh giá năng lực dựa vào kết quả học tập:
</div>
<div class="ct_subitem" id="survey6">
   Bạn hãy chọn vào khối thi mà bạn đã tham gia vào kỳ thi tuyển sinh ĐH-CĐ và bạn căn cứ vào học bạ lớp 10, 11, 12 điền điểm trung bình vào bảng bên dưới
   <p>
   1.	Khối thi:  
       <asp:CheckBox ID="chkA" runat="server" Text="A" /> -   <asp:CheckBox ID="chkA1" runat="server" Text="A1" />  -   <asp:CheckBox ID="chkB" runat="server" Text="B" />  -  <asp:CheckBox ID="chkC" runat="server" Text="C" /> -  <asp:CheckBox ID="chkD" runat="server" Text="D" />  -  <asp:CheckBox ID="chkOrders" runat="server"  />  
       <asp:TextBox ID="txtOther" runat="server"></asp:TextBox>(năng khiếu)
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
               Tiếng Anh</td>
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
     <asp:Button ID="Button9" runat="server" Text="Next" CssClass="btnNext" OnClick="btn_check" />
    <input value="Back" type="button" id="Button5" class="btnNext" onclick="showSurvey('survey4')" />
</div>
</asp:Content>
