using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class administrator_AdminMasterPage : BaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if( Session["UserLogin"] == null)
			Response.Redirect("login.aspx");

    }
}
