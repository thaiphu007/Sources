using System;
using System.Linq;
using System.Web.UI;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class ViewResult : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    using (var db=new KHAOSATDataContext())
                    {
                        var info =
                            (from t in db.Testers where t.Id == int.Parse(Request.QueryString["id"]) select t).
                                FirstOrDefault();
                        if(info!=null)
                        {
                            liFullName.Text = info.FullName;
                            liR.Text = info.ResultR.ToString();
                            liI.Text = info.ResultI.ToString();
                            liE.Text = info.ResultE.ToString();
                            liS.Text = info.ResultS.ToString();
                            liC.Text = info.ResultC.ToString();
                            liA.Text = info.ResultA.ToString();

                        }
                    }
                }
            }
        }
    }
}