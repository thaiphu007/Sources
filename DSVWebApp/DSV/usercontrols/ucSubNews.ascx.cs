using System;
using System.Web.UI;

namespace DSV.usercontrols
{
    public partial class ucSubNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadSubMenu();
        }
        public void LoadSubMenu()
        {
            rptSub.DataSource = CategoryBussiness.GetAllCategoryNews(false);
            rptSub.DataBind();
        }

    }
}