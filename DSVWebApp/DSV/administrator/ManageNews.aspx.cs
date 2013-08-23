using System;
using System.Web.UI;

namespace DSV.administrator
{
    public partial class ManageNews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }
        private void LoadData()
        {
            rptList.DataSource = CategoryBussiness.GetAllNews(string.Empty);
            rptList.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addNews.aspx?act=add");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CategoryBussiness.DeleteNews(Request.Form["ckselect"]);
            LoadData();
        }
    }
}