using System;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_check(object sender, EventArgs e)
        {
          //save tester
            if(!CheckValid()) return;
            int id = 0;
            using (var db=new KHAOSATDataContext())
            {
                var info = new Tester
                               {
                                   FullName = txtFullName.Text,
                                   Address = txtAddress.Text,
                                   Favorite = txtFavorite.Text,
                                   Gender = radNam.Checked,
                                   DateOfBirth = txtBirthDate.SelectedDate,
                                   WhereBirth = txtWhereBirth.Text,
                                   Phone = txtPhone.Text,
                                   HightSchool = txtHighSchool.Text,
                                   Province = txtProvince.Text,
                                   Department = txtDepartment.Text,
                                   Reason = txtReason.Text,
                                   Scores = double.Parse(string.IsNullOrEmpty(txtPointTest.Text.Trim()) ? "0" : txtPointTest.Text.Trim()),
                                   SchoolTest = txtSchoolTest.Text,
                                   A = chkBlockA.Checked,
                                   B = chkBlockB.Checked,
                                   C=chkBlockC.Checked,
                                   D=chkBlockD.Checked,
                                   Orther = chkBlockOrther.Checked?txtBlockOrther.Text:string.Empty,
                                   SchoolLearning = txtShoolLearning.Text,
                                   IsMatch = radMatch.Checked,
                                   Reason1 = txtReason1.Text
                               };
                db.Testers.InsertOnSubmit(info);
                Session["TesterId"] = info.Id;
                db.SubmitChanges();
                //save answer
                ucGroup1.SetPoint();
                ucGroup2.SetPoint();
                ucGroup3.SetPoint();
                ucGroup4.SetPoint();
                //save average
                int r=0;
                int i=0;
                int a=0;
                int _e=0;
                int c=0;
                int s=0;
                GetTotalGroupPoint(ref r,ref  i,ref a,ref _e,ref c,ref s);
                db.PointAverages.InsertOnSubmit(GetInfo(txtToan10, txtToan11, txtToan12, info.Id, SubjectName.Toan));
                db.PointAverages.InsertOnSubmit(GetInfo(txtVatLy10, txtVatLy11, txtVatLy12, info.Id, SubjectName.Ly));
                db.PointAverages.InsertOnSubmit(GetInfo(txtHoaHoc10, txtHoaHoc11, txtHoaHoc12, info.Id, SubjectName.Hoa));
                db.PointAverages.InsertOnSubmit(GetInfo(txtVan10, txtVan11, txtVan12, info.Id, SubjectName.Van));
                db.PointAverages.InsertOnSubmit(GetInfo(txtLichSu10, txtLichSu11, txtLichSu12, info.Id, SubjectName.Su));
                db.PointAverages.InsertOnSubmit(GetInfo(txtDiaLy10, txtDiaLy11, txtDiaLy12, info.Id, SubjectName.Dia));
                db.PointAverages.InsertOnSubmit(GetInfo(txtTiengAnh10, txtTiengAnh11, txtTiengAnh12, info.Id, SubjectName.Anh));
                db.PointAverages.InsertOnSubmit(GetInfo(txtSinh10, txtSinh11, txtSinh12, info.Id, SubjectName.Sinh));
             

                info.ResultA = a;
                info.ResultR = r;
                info.ResultC = c;
                info.ResultI = i;
                info.ResultS = s;
                info.ResultE = _e;
                db.SubmitChanges();
                id = info.Id;
            }

            Response.Redirect(string.Format("/ViewResult.aspx?id={0}",id));
            
        }
        private PointAverage GetInfo(TextBox txt10,TextBox txt11,TextBox txt12,int testerId,SubjectName sbj)
        {
            var average = new PointAverage
            {
                Ten =Commons.TryParseFloat(txt10.Text),
                Eleven = Commons.TryParseFloat(txt11.Text),
                Twelve = Commons.TryParseFloat(txt12.Text),
                SubjectId = (int)sbj,
                Block =
                    string.Format("{0};{1};{2},{3};{4};{5}", chkA.Checked ? "1" : "0",
                                  chkA1.Checked ? "1" : "0", chkB.Checked ? "1" : "0",
                                  chkC.Checked ? "1" : "0", chkD.Checked ? "1" : "0",
                                  chkOrders.Checked ? txtOther.Text : ""),
                TesterId = testerId
            };
            return average;
        }
        private void GetTotalGroupPoint(ref int r,ref  int i, ref int a,ref  int e,ref  int c, ref int s)
        {
             r =ucGroup1.GroupR + ucGroup2.GroupR + ucGroup3.GroupR + ucGroup4.GroupR;
             i = ucGroup1.GroupI + ucGroup2.GroupI + ucGroup3.GroupI + ucGroup4.GroupI;
             a = ucGroup1.GroupA  + ucGroup2.GroupA + ucGroup3.GroupA + ucGroup4.GroupA;
             e = ucGroup1.GroupE + ucGroup2.GroupE + ucGroup3.GroupE + ucGroup4.GroupE;
             c = ucGroup1.GroupC + ucGroup2.GroupC + ucGroup3.GroupC + ucGroup4.GroupC;
             s = ucGroup1.GroupS + ucGroup2.GroupS + ucGroup3.GroupS + ucGroup4.GroupS;
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

    }
}