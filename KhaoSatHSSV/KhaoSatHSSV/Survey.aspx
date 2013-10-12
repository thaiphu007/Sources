<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="KhaoSatHSSV.Survey" %>
<%@ Register src="Control/ucGroup.ascx" tagname="ucGroup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<script type="text/javascript">
    $(document).ready(function () {
        HideSurvey();
        $("#survey1").show();
    });

    function showSurvey(id) {
        HideSurvey();
        $("#" + id).show();

    }
    function HideSurvey() {
        $("#survey1").hide();
        $("#survey2").hide();
        $("#survey3").hide();
        $("#survey4").hide();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="ct_Header">PHIẾU KHẢO SÁT THÔNG TIN</div>
   
    <div class="ct_item">
    I. Thông tin cá nhân
</div>
    <table class="style1" cellpadding="0" cellspacing="0" >
    <tr>
        <td width="150px">
            Họ Tên:</td>
        <td>
            <asp:TextBox ID="txtFullName" runat="server" Width="500px" MaxLength="50" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Địa chỉ:&nbsp;</td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Width="500px" MaxLength="250" Enabled="False"></asp:TextBox>
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
 <asp:Button ID="Button9" runat="server" Text="Next" CssClass="btnNext" OnClick="btn_check" />
    <input value="Back" type="button" id="Button5" class="btnNext" onclick="showSurvey('survey3')" />
</div>

</asp:Content>
