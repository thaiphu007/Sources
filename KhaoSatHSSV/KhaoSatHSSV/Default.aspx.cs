using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            ucGroup1.SetPoint();
            ucGroup2.SetPoint();
            ucGroup3.SetPoint();
            ucGroup4.SetPoint();
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
                                   B = chkBlockB.Checked

                               };
                
            }
            
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
    }
}