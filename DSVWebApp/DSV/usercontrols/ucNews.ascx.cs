using System;
using System.Web.UI;

namespace DSV.usercontrols
{
    public partial class ucNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadData();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                rptNews.DataSource = CategoryBussiness.GetNewsTopOne(true);
                rptNews.DataBind();
            }
            else
            {
                try
                {
                    rptNews.DataSource = CategoryBussiness.GetNews(Convert.ToInt32(Request.QueryString["cid"]), true);
                    rptNews.DataBind();
                }
                catch {}
                
            }
        
    }
    }
}