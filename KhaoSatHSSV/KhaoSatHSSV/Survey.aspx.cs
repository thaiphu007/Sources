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
            if(string.IsNullOrEmpty(Request.QueryString["mode"]))
                Response.Redirect(string.Format("/Results.aspx?id={0}", id));
            Response.Redirect(string.Format("/ResultId3.aspx?id={0}", id));

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

     
      

        private void GetTotalGroupPoint(ref int r, ref  int i, ref int a, ref  int e, ref  int c, ref int s)
        {
            r = ucGroup1.GroupR;
            i = ucGroup1.GroupI;
            a = ucGroup1.GroupA;
            e = ucGroup1.GroupE;
            c = ucGroup1.GroupC;
            s = ucGroup1.GroupS;
        }

       

    }
}