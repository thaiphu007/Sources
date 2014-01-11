using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Completed : System.Web.UI.Page
    {
        private readonly KHAOSATDataContext db = new KHAOSATDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ma"]))
                {
                    var listtruong = from t in db.Colleges
                                     where Request.QueryString["ma"].ToLower().Trim().Contains(t.MaTruong.ToLower().Trim())
                                     select t;
                    if (listtruong.Any())
                    {
                        rptTruong.DataSource = listtruong;
                        rptTruong.DataBind();
                    }
                }

            }

        }
        public override void Dispose()
        {
            db.Dispose();
            base.Dispose();

        }
    }
}