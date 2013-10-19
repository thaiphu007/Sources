<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Root.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KhaoSatHSSV.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="95%" cellpadding="3" cellspacing="0" border="1">
        <tr>
            <td colspan="7" align="center"><strong>Phiếu Đăng Ký</strong></td>
        </tr>
        <tr >
            <td style="width: 130px">Tên đăng nhập: (<span style="color: red">*</span>)</td>
            <td style="width: 200px">
                <asp:TextBox ID="txtUser" Width="180px" MaxLength="50" runat="server"></asp:TextBox></td>
            <td style="width: 120px">Mật Khẩu: (<span style="color: red">*</span>)</td>
            <td style="width: 200px"><asp:TextBox ID="txtPass" Width="180px" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox></td>
             <td style="width: 120px">Xác nhận lại: (<span style="color: red">*</span>)</td>
            <td style="width: 200px" colspan="2"><asp:TextBox ID="txtConfirm" Width="180px" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
         <tr >
            <td style="width: 130px">Họ tên: (<span style="color: red">*</span>)</td>
            <td style="width: 200px">
                <asp:TextBox ID="txtHoTen" Width="180px" MaxLength="50" runat="server"></asp:TextBox></td>
            <td style="width: 120px">Phái:</td>
            <td style="width: 200px">  <asp:RadioButton ID="radNam" runat="server" GroupName="phai" Checked="True" Text="Nam" />
            <asp:RadioButton ID="radNu" runat="server" GroupName="phai" Text="Nữ" /></td>
             <td style="width: 120px">Ngày sinh: (<span style="color: red">*</span>)</td>
            <td style="width: 200px" colspan="2"><telerik:RadDatePicker ID="txtBirthDate" runat="server" Skin="Default" Width="100px">
                <DateInput ID="DateInput1" DateFormat="dd/MM/yyyy" runat="server">
                </DateInput>
            </telerik:RadDatePicker></td>
        </tr>
         <tr >
            <td style="width: 130px">Địa chỉ:</td>
            <td style="width: 200px">
                <asp:TextBox ID="txtAddress" Width="180px" MaxLength="50" runat="server"></asp:TextBox></td>
            <td style="width: 120px">Nơi sinh: </td>
            <td style="width: 200px">  <asp:DropDownList ID="ddlWhereBirth" runat="server" Width="185px">
            </asp:DropDownList></td>
             <td style="width: 120px">Điện thoại:</td>
            <td style="width: 200px" colspan="2"><asp:TextBox ID="txtDienThoai" Width="180px" MaxLength="20" runat="server"></asp:TextBox></td>
        </tr>
        <tr >
            <td style="width: 130px">Học tại tỉnh:</td>
            <td style="width: 200px">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
               <asp:DropDownList ID="ddlProvince" runat="server" Width="185px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedChanged">
            </asp:DropDownList>
            </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
            <td style="width: 120px">Trường THPT: </td>
            <td style="width: 200px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTruong" runat="server" Width="185px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
             <td style="width: 120px">Email: (<span style="color: red">*</span>)</td>
            <td style="width: 200px" colspan="2"><asp:TextBox ID="txtEmail" Width="180px" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7" align="center">
             <strong>   Hãy chọn nhóm ngành bạn dự định học:</strong>
            </td>
        </tr>
        <tr >
            <td colspan="2" align="right">Nhóm ngành 1:</td>
            <td colspan="5">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:DropDownList ID="ddlNhomNganh1" runat="server" Width="470px"  AutoPostBack="True" OnSelectedIndexChanged="ddl_NhomNganh1_selectedChanged">
            </asp:DropDownList>
            </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
        <tr >
            <td colspan="2" align="right"><strong>Ngành 1:</strong></td>
            <td colspan="5">    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:DropDownList ID="ddlNganh1" runat="server" Width="470px">
            </asp:DropDownList>   </ContentTemplate>
              <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNhomNganh1" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel></td>
        </tr>
        <tr >
            <td colspan="2" align="right">Nhóm ngành 2:</td>
            <td colspan="5">    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:DropDownList ID="ddlNhomNganh2" runat="server" Width="470px"  AutoPostBack="True" OnSelectedIndexChanged="ddl_NhomNganh2_selectedChanged">
            </asp:DropDownList>   </ContentTemplate>
                    </asp:UpdatePanel></td>
        </tr>
        <tr >
            <td colspan="2" align="right"><strong>Ngành 2:</strong></td>
            <td colspan="5">    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:DropDownList ID="ddlNganh2" runat="server" Width="470px">
            </asp:DropDownList>   </ContentTemplate> <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlNhomNganh2" EventName="SelectedIndexChanged" />
                    </Triggers>
                    </asp:UpdatePanel></td>
        </tr>
         <tr>
            <td colspan="7" align="center">
             <strong> Chọn nhóm khả năng, sở thích phù hợp nhất với bạn (chọn ít nhất 1 hoặc 2 nhóm)</strong>
            </td>
        </tr>
         <tr>
            <td colspan="6" align="center">
              Có khả năng về kỹ thuật, công nghệ, hệ thống; thích làm việc với đồ vật, máy móc, động thực vật; 
thích làm các công việc ngoài trời.											

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomR" runat="server" />
                </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
              Có khả năng về quan sát, khám phá, nghiên cứu, phân tích đánh giá và giải quyết các vấn đề.											

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomI" runat="server" />
                </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
              Có khả năng về nghệ thuật, khả năng về trực giác, khả năng tưởng tượng cao;
thích làm việc trong các môi trường mang tính ngẫu hứng, không khuôn mẫu.											

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomA" runat="server" />
                </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
              Có khả năng về ngôn ngữ, giảng giải, thích làm những việc như giảng giải, cung cấp thông tin, sự chăm sóc, giúp đỡ, hoặc huấn luyện cho người khác.											

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomS" runat="server" />
                </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
              Có khả năng về kinh doanh, mạnh bạo, dám nghĩ dám làm, có thể gây ảnh hưởng, thuyết phục người khác, có khả năng quản lý.										

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomE" runat="server" />
                </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
              Có khả năng về số học, thích thực hiện những công việc chi tiết, thích làm việc với những số liệu, theo chỉ dẫn của người khác hoặc các công việc văn phòng.										

            </td>
            <td style="width: 50px" align="center">
                <asp:CheckBox ID="chkNhomC" runat="server" />
                </td>
        </tr>

        
        <tr>
            <td colspan="7" align="center">
                <asp:Button ID="btnDangKy" runat="server" Text="Đăng Ký" OnClick="btnDangKy_Click" />
                <asp:Label ID="lblError" ForeColor="red" runat="server" Text=""></asp:Label>
             </td>
        </tr>
    </table>
</asp:Content>
