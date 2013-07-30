using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_ucMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<tbl_Category> categories = CategoryBussiness.GetParents_V2().OrderBy(c=>c.DisplayOrder).ToList();
            rptMenu.DataSource = categories;
            rptMenu.DataBind();
        }
    }
    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        tbl_Category category= e.Item.DataItem as tbl_Category;
        usercontrols_SubMenu sub = e.Item.FindControl("submenu") as usercontrols_SubMenu;
        if (category != null&& sub!=null)
        {
            List<tbl_Category> list = CategoryBussiness.GetChilds_V2(category.Id);
            if (list != null && list.Count() > 0)
            {
                sub.PareantCateName = Commons.RemoveSpecialCharacters(category.CateName);
                sub.LoadSubMenu(list);
            }
            else
                sub.Visible = false;
        }
    }
}
