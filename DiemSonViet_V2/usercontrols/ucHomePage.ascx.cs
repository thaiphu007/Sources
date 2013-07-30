using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_ucHomePage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadData();
    }
    private void LoadData()
    {
        rptHomePage.DataSource = ContentPagesBussiness.GetContentHomePage();
        rptHomePage.DataBind();
    }
}
