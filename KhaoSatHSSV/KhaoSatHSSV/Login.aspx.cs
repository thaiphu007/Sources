using System;
using System.Linq;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenDangNhap.Text.Trim()))
            {
                lblError.Text = "Nhập Tên Đăng Nhập";
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                lblError.Text = "Nhập mật khẩu";
                return;
            }
            using (var db=new KHAOSATDataContext())
            {
                var info =
                    (from u in db.SinhViens
                     where u.TenDangNhap == txtTenDangNhap.Text && u.Passwords == txtMatKhau.Text
                     select u).FirstOrDefault();
                if(info!=null)
                {
                    Session["SVID"] = info.Id;
                    Response.Redirect("/Survey.aspx");
                    Session["UserName"] = txtTenDangNhap.Text;
                }else
                {
                    lblError.Text = "Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại";
                }
            }
        }
    }
}