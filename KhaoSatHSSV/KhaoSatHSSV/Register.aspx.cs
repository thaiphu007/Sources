using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void ddlProvince_SelectedChanged(object sender, EventArgs e)
        {
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.TruongTHPTs where t.MaTinh == Commons.TryParseInt(ddlProvince.SelectedValue) select t);
                ddlTruong.DataSource = list;
                ddlTruong.DataTextField = "TenTruong";
                ddlTruong.DataValueField = "MaTruong";
                ddlTruong.DataBind();
            }
        }

        protected void ddl_NhomNganh1_selectedChanged(object sender, EventArgs e)
        {
          
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.Nganhs where t.Ma.Substring(0,8).Trim().Equals(ddlNhomNganh1.SelectedValue.Trim()) select t);
                ddlNganh1.DataSource = list;
                ddlNganh1.DataTextField = "TenNganh";
                ddlNganh1.DataValueField = "Ma";
                ddlNganh1.DataBind();
            }
          
        }

        protected void ddl_NhomNganh2_selectedChanged(object sender, EventArgs e)
        {
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.Nganhs where t.Ma.Substring(0, 8) == ddlNhomNganh2.SelectedValue select t);
                ddlNganh2.DataSource = list;
                ddlNganh2.DataTextField = "TenNganh";
                ddlNganh2.DataValueField = "Ma";
                ddlNganh2.DataBind();
            }
            UpdatePanel6.Update();
        }

        private void LoadData()
        {
            using (var db = new KHAOSATDataContext())
            {
                ddlProvince.DataSource = db.Provinces;
                ddlProvince.DataTextField = "ProvinceName";
                ddlProvince.DataValueField = "Code";
                ddlProvince.DataBind();

                ddlWhereBirth.DataSource = db.Provinces;
                ddlWhereBirth.DataTextField = "ProvinceName";
                ddlWhereBirth.DataValueField = "Code";
                ddlWhereBirth.DataBind();

                ddlProvince.SelectedIndex = 0;
                ddlProvince_SelectedChanged(null, null);

                ddlNhomNganh1.DataSource = db.NhomNganhs;
                ddlNhomNganh1.DataTextField = "TenNhom";
                ddlNhomNganh1.DataValueField = "Ma";
                ddlNhomNganh1.DataBind();
                ddlNhomNganh1.SelectedIndex = 0;
                ddl_NhomNganh1_selectedChanged(null, null);

                UpdatePanel4.Update();

                ddlNhomNganh2.DataSource = db.NhomNganhs;
                ddlNhomNganh2.DataTextField = "TenNhom";
                ddlNhomNganh2.DataValueField = "Ma";
                ddlNhomNganh2.DataBind();
                ddlNhomNganh2.SelectedIndex = 0;
                ddl_NhomNganh2_selectedChanged(null, null);
                UpdatePanel6.Update();


            }
        }

        private long GetInfo()
        {
            long SVID = 0;
            using (var db = new KHAOSATDataContext())
            {
                var info = new SinhVien
                               {
                                   TenDangNhap = txtUser.Text.Trim(),
                                   HoTen = txtHoTen.Text.Trim(),
                                   Passwords = txtPass.Text.Trim(),
                                   NgaySinh = txtBirthDate.SelectedDate,
                                   NoiSinh = ddlWhereBirth.Text,
                                   GioiTinh = radNam.Checked,
                                   DiaChi = txtAddress.Text.Trim(),
                                   DienThoai = txtDienThoai.Text,
                                   NoiHocTHPT = ddlProvince.SelectedValue,
                                   TruongTHPT = int.Parse(string.IsNullOrEmpty(ddlTruong.SelectedValue)?"0":ddlTruong.SelectedValue),
                                   Email = txtEmail.Text.Trim(),
                                   MaNhom1 = ddlNhomNganh1.SelectedValue,
                                   MaNganh1 = ddlNganh1.SelectedValue,
                                   MaNhom2 = ddlNhomNganh2.SelectedValue,
                                   MaNganh2 = ddlNganh2.SelectedValue,
                                   KhaNang = string.Format("{0};{1};{2};{3}:{4};{5}", chkNhomR.Checked ? 1 : 0, chkNhomI.Checked ? 2 : 0, chkNhomA.Checked ? 3 : 0, chkNhomS.Checked ? 4 : 0, chkNhomE.Checked ? 5 : 0, chkNhomC.Checked ? 6 : 0),
                                   CreateDate = DateTime.Now
                               };
                //R:I:A:S:E:C
                db.SinhViens.InsertOnSubmit(info);
                db.SubmitChanges();
                SVID = info.Id;
            }
            return SVID;
        }
        private bool valid()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtUser.Text.Trim())){
                txtUser.Focus();
                lblError.Text = "Nhập Tên Đăng Nhập!";
                result = false;
            }else if(string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                txtHoTen.Focus();
                lblError.Text = "Nhập Họ Tên!";
                result = false;
            }else if(string.IsNullOrEmpty(txtPass.Text.Trim())){
                txtPass.Focus();
                lblError.Text = "Nhập Mật Khẩu!";
                result = false;
            }
            else if (string.IsNullOrEmpty(txtConfirm.Text.Trim())){
                txtConfirm.Focus();
                lblError.Text = "Nhập Xác Nhận Mật Khẩu!";
                result = false;
            }
            else if (!txtConfirm.Text.Trim().Equals(txtPass.Text.Trim())){
                txtConfirm.Focus();
                lblError.Text = "Xác Nhận Mật Khẩu Không Chính Xác !";
                result = false;
            }
            else if(txtBirthDate.SelectedDate==null)
            {
                txtBirthDate.Focus();
                lblError.Text = "Nhập  ngày sinh !";
                result = false;
            }
            else if (DateTime.Now.Date.Year-txtBirthDate.SelectedDate.Value.Year<14){
                txtBirthDate.Focus();
                lblError.Text = "Bạn chưa đủ tuổi.!";
                result = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim())){
                txtEmail.Focus();
                lblError.Text = "Nhập Email !";
                result = false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                txtEmail.Focus();
                lblError.Text = "Nhập  Email không đúng !";
                result = false;
            }
            else  if(!IsExistEmailOrUserName(true))
            {
                txtUser.Text = "Tên đăng nhập  đã tồn tại vui lòng điền tên khác !";
                result = false;
            }
            else if (!IsExistEmailOrUserName())
            {
                txtEmail.Text = "Email đã tồn tại vui lòng điền email khác !";
                result = false;
            }

            return result;
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                var m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsExistEmailOrUserName(bool isUserName=false)
        {
            bool IsExist;
            using (var db=new KHAOSATDataContext())
            {
                var info = isUserName ? (from sv in db.SinhViens
                                         where sv.TenDangNhap.ToLower().Equals(txtUser.Text.Trim().ToLower())
                                         select sv).FirstOrDefault() : (from sv in db.SinhViens
                                                                        where sv.Email.ToLower().Equals(txtEmail.Text.Trim().ToLower()) ||
                                                                                                        sv.TenDangNhap.ToLower().Equals(
                                                                                                            txtUser.Text.Trim().ToLower())
                                                                        select sv).FirstOrDefault();
               
                   IsExist = info != null;
               
            }
            return IsExist;
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if(valid())
            {
                Session["SVID"] = GetInfo();
                Response.Redirect("/survery.aspx");
                Session["UserName"] = txtUser.Text;
            }
        }
    }
}