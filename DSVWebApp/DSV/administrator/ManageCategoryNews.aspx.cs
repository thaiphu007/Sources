using System;
using System.Web.UI;

namespace DSV.administrator
{
    public partial class ManageCategoryNews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadData();
        }
        private void LoadData()
        {
            rptList.DataSource = CategoryBussiness.GetAllCategoryNews();
            rptList.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addCategoryNews.aspx?act=add");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CategoryBussiness.DeleteCategoryNews(Request.Form["ckselect"]);
            LoadData();
        }
    }
}