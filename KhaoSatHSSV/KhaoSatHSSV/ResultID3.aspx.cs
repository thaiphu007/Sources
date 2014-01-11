using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class ResultID3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    using (var db = new KHAOSATDataContext())
                    {
                        var info =(from s in db.SinhViens where s.Id == long.Parse(Request.QueryString["id"]) select s).
                                FirstOrDefault();
                       
                    }
                }
                else
                {
                    Response.Redirect("/login.aspx");
                }
            }
        }
    }
}