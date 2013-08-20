using System;
using System.Web.UI;
using DSV;

public partial class usercontrols_ucHomePage : UserControl
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
