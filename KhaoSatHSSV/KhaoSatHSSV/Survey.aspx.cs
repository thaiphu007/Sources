using System;
using System.Linq;
using System.Web.UI;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Survey : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
          {
              if (Session["SVID"] != null)
                  LoadData();
              else
                  Response.Redirect("/register.aspx");
          }
        }

        protected void btn_check(object sender, EventArgs e)
        {
            //save tester
          
            var id=(long)Session["SVID"];
            using (var db = new KHAOSATDataContext())
            {
                var info = (from sv in db.SinhViens where sv.Id == id select sv).FirstOrDefault();
                if (info != null)
                {
                    //save answer
                    ucGroup1.SetPoint();
                    ucGroup2.SetPoint();
                    ucGroup3.SetPoint();
                    ucGroup4.SetPoint();
                    //save average
                    int r = 0;
                    int i = 0;
                    int a = 0;
                    int _e = 0;
                    int c = 0;
                    int s = 0;
                    GetTotalGroupPoint(ref r, ref i, ref a, ref _e, ref c, ref s);
                    info.ResultA = a;
                    info.ResultR = r;
                    info.ResultC = c;
                    info.ResultI = i;
                    info.ResultS = s;
                    info.ResultE = _e;
                    db.SubmitChanges();
                    id = info.Id;
                }
            }

            Response.Redirect(string.Format("/Results.aspx?id={0}", id));

        }

        private void LoadData()
        {
            using (var db = new KHAOSATDataContext())
            {
                var id = (long)Session["SVID"];
                var info = (from sv in db.SinhViens where sv.Id == id select sv).FirstOrDefault();
                if(info!=null)
                {
                    txtFullName.Text = info.HoTen;
                    txtAddress.Text = info.DiaChi;
                }
            }
        }

        //private PointAverage GetInfo(TextBox txt10, TextBox txt11, TextBox txt12, int testerId, SubjectName sbj)
        //{
        //    var average = new PointAverage
        //    {
        //        Ten = Commons.TryParseFloat(txt10.Text),
        //        Eleven = Commons.TryParseFloat(txt11.Text),
        //        Twelve = Commons.TryParseFloat(txt12.Text),
        //        SubjectId = (int)sbj,
        //        Block = string.Format("{0};{1};{2},{3};{4};{5}", "0", "0", "0", "0", "0", ""),
        //        TesterId = testerId
        //    };
        //    return average;
        //}

      

        private void GetTotalGroupPoint(ref int r, ref  int i, ref int a, ref  int e, ref  int c, ref int s)
        {
            r = ucGroup1.GroupR +ucGroup2.GroupR + ucGroup3.GroupR + ucGroup4.GroupR;
            i = ucGroup1.GroupI +ucGroup2.GroupI + ucGroup3.GroupI + ucGroup4.GroupI;
            a = ucGroup1.GroupA +ucGroup2.GroupA + ucGroup3.GroupA + ucGroup4.GroupA;
            e = ucGroup1.GroupE +ucGroup2.GroupE + ucGroup3.GroupE + ucGroup4.GroupE;
            c = ucGroup1.GroupC +ucGroup2.GroupC + ucGroup3.GroupC + ucGroup4.GroupC;
            s = ucGroup1.GroupS +ucGroup2.GroupS + ucGroup3.GroupS + ucGroup4.GroupS;
        }

       

    }
}