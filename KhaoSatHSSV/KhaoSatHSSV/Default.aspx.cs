using System;
using System.Linq;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
                ddlProvince.SelectedIndex = 0;
                ddlProvince_SelectedChanged(null,null);
                ddlDangHoc.SelectedIndex = 0;
                ddlDangHoc_SelectedChanged(null, null);
            }
        }

        protected void btn_check(object sender, EventArgs e)
        {
            //save tester
            if(!CheckValid()) return;
            int id;
            using (var db=new KHAOSATDataContext())
            {
                var info = new Tester
                               {
                                   FullName = txtFullName.Text,
                                   Address = txtAddress.Text,
                                   Favorite = txtFavorite.Text,
                                   Gender = radNam.Checked,
                                   DateOfBirth = txtBirthDate.SelectedDate,
                                   WhereBirth = ddlWhereBirth.Text,
                                   Phone = txtPhone.Text,
                                   HightSchool = ddlTruong.Text,
                                   Province = ddlProvince.Text,
                                   Department = txtDepartment.Text,
                                   Reason = txtReason.Text,
                                   Scores = double.Parse(string.IsNullOrEmpty(txtPointTest.Text.Trim()) ? "0" : txtPointTest.Text.Trim()),
                                   SchoolTest = ddlDuThi.Text,
                                   A = chkBlockA.Checked,
                                   B = chkBlockB.Checked,
                                   C=chkBlockC.Checked,
                                   D=chkBlockD.Checked,
                                   Orther = chkBlockOrther.Checked?txtBlockOrther.Text:string.Empty,
                                   SchoolLearning = ddlDangHoc.Text,
                                   IsMatch = radMatch.Checked,
                                   Reason1 = txtReason1.Text,
                                   MaNganh = ddlNganhHoc.SelectedValue
                               };
                db.Testers.InsertOnSubmit(info);
                db.SubmitChanges();
                Session["TesterId"] = info.Id;
                //save answer
                ucGroup1.SetPoint();
                //ucGroup2.SetPoint();
                //ucGroup3.SetPoint();
               // ucGroup4.SetPoint();
                //save average
                //int r=0;
                //int i=0;
                //int a=0;
                //int _e=0;
                //int c=0;
                //int s=0;
                //GetTotalGroupPoint(ref r,ref  i,ref a,ref _e,ref c,ref s);
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());


                info.ResultA = ucGroup1.GroupA;
                info.ResultR = ucGroup1.GroupR;
                info.ResultC = ucGroup1.GroupC;
                info.ResultI = ucGroup1.GroupI;
                info.ResultS = ucGroup1.GroupS;
                info.ResultE = ucGroup1.GroupE;
                db.SubmitChanges();
                id = info.Id;
            }

            Response.Redirect(string.Format("/ViewResult.aspx?id={0}",id));
            
        }

        private void LoadData()
        {
            using (var db = new KHAOSATDataContext())
            {
                ddlProvince.DataSource = db.Provinces;
                ddlProvince.DataTextField = "ProvinceName";
                ddlProvince.DataValueField= "Code";
                ddlProvince.DataBind();

                ddlWhereBirth.DataSource = db.Provinces;
                ddlWhereBirth.DataTextField = "ProvinceName";
                ddlWhereBirth.DataValueField = "Code";
                ddlWhereBirth.DataBind();

                ddlDuThi.DataSource = db.Colleges;
                ddlDuThi.DataTextField = "TenTruong";
                ddlDuThi.DataValueField = "MaTruong";
                ddlDuThi.DataBind();

                ddlDangHoc.DataSource = db.Colleges;
                ddlDangHoc.DataTextField = "TenTruong";
                ddlDangHoc.DataValueField = "MaTruong";
                ddlDangHoc.DataBind();

                ddlNganhHoc.DataSource = db.Nganhs;
                ddlNganhHoc.DataTextField = "TenNganh";
                ddlNganhHoc.DataValueField = "Ma";
                ddlNganhHoc.DataBind();
                

           

            }
        }

        private PointAverage GetInfo(TextBox txt10,TextBox txt11,TextBox txt12,int testerId,SubjectName sbj)
        {
            var average = new PointAverage
            {
                Ten =Commons.TryParseFloat(txt10.Text),
                Eleven = Commons.TryParseFloat(txt11.Text),
                Twelve = Commons.TryParseFloat(txt12.Text),
                SubjectId = (int)sbj,
                Block = string.Format("{0};{1};{2},{3};{4};{5}", "0", "0", "0", "0", "0", ""),
                TesterId = testerId
            };
            return average;
        }

        private PointAverage GetInfo()
        {
            var average = new PointAverage
            {
                Ten = 0,
                Eleven = 0,
                Twelve = 0,
                SubjectId = null,
                Block =
                    string.Format("{0};{1};{2},{3};{4};{5}",  "0","0",  "0","0",  "0",""),
                TesterId = null
            };
            return average;
        }

        private void GetTotalGroupPoint(ref int r,ref  int i, ref int a,ref  int e,ref  int c, ref int s)
        {
            r = ucGroup1.GroupR;// +ucGroup2.GroupR + ucGroup3.GroupR + ucGroup4.GroupR;
            i = ucGroup1.GroupI;// +ucGroup2.GroupI + ucGroup3.GroupI + ucGroup4.GroupI;
            a = ucGroup1.GroupA;// +ucGroup2.GroupA + ucGroup3.GroupA + ucGroup4.GroupA;
            e = ucGroup1.GroupE;// +ucGroup2.GroupE + ucGroup3.GroupE + ucGroup4.GroupE;
            c = ucGroup1.GroupC;// +ucGroup2.GroupC + ucGroup3.GroupC + ucGroup4.GroupC;
            s = ucGroup1.GroupS;// +ucGroup2.GroupS + ucGroup3.GroupS + ucGroup4.GroupS;
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                ShowMessage("Nhập Họ tên");
                return false;
            }
            if (!string.IsNullOrEmpty(txtPointTest.Text.Trim()) && (txtPointTest.Text.Trim().Length>2|| Commons.TryParseFloat(txtPointTest.Text)>30))
            {

                ShowMessage("Điểm Thi ĐH, CĐ quá lớn.");
                return false;
            }
            return true;
        }

        private void ShowMessage(string message)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), string.Format("message_{0}", DateTime.Now.Ticks.ToString()), string.Format("<script type='text/javascript'> $(document).ready(function(){{alert('{0}');showSurvey('survey5')}});</script>", message));
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

        protected void ddlDangHoc_SelectedChanged(object sender, EventArgs e)
        {
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.Nganhs join dn in db.DHCD_Nganhs on t.Ma equals dn.MaNganh 
                     where dn.MaTruong==ddlDangHoc.SelectedValue select t);
                ddlNganhHoc.DataSource = list;
                ddlNganhHoc.DataTextField = "TenNganh";
                ddlNganhHoc.DataValueField = "Ma";
                ddlNganhHoc.DataBind();
            }
        }
    }
}