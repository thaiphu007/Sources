using System;
using System.Linq;
using System.Web.UI;
using DSV;

public partial class administrator_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadData();
    }
    private void LoadData()
    {
        rptList.DataSource = CategoryBussiness.GetAll_V2().OrderBy(c=>c.ParentId);
        rptList.DataBind();
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("addcategory.aspx?act=add");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CategoryBussiness.Delete_V2(Request.Form["ckselect"]);
        LoadData();
    }
}
