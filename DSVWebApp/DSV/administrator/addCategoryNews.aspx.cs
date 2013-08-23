using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSV.administrator
{
    public partial class addCategoryNews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadData();
        }
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                try
                {
                    Convert.ToInt32(Request.QueryString["id"]);
                    hdID.Value = Request.QueryString["id"];
                    Category_New Info = CategoryBussiness.GetInfo_Categorynews(Convert.ToInt32(Request["id"]));
                    if (Info != null)
                    {
                        txtCateName.Text = Info.CategoryName;
                        txtDisplayOrder.Text = Info.DisplayOrder == null ? "" : Info.DisplayOrder.ToString();
                        chkHidden.Checked = Info.IsHidden;
                    }
                }
                catch { }
            }
        }

        private Category_New GetCategory()
        {
            var Info = new Category_New
                           {
                               CategoryName = txtCateName.Text,
                               DisplayOrder = Convert.ToInt32(txtDisplayOrder.Text),
                               IsHidden = chkHidden.Checked
                           };
            if (!string.IsNullOrEmpty(hdID.Value.Trim()))
                Info.Id = Convert.ToInt32(hdID.Value);
            return Info;
        }

        private bool CheckValid()
        {
            bool isValid = true;
            string ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(txtCateName.Text.Trim()))
            {
                ErrorMessage = Resources.ResourceMessage.ERR_CATENAME;
                isValid = false;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtDisplayOrder.Text);
                }
                catch
                {
                    ErrorMessage = Resources.ResourceMessage.ERR_DISPLAYORDER;
                    isValid = false;
                }
            }
            lblError.Text = ErrorMessage;
            return isValid;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var button1 = sender as Button;
            if (button1 != null && button1.Equals(btnBack))
                Response.Redirect("managecategorynews.aspx");
            if (CheckValid())
            {
                CategoryBussiness.Save_CategoryNews(GetCategory());
                var button = sender as Button;
                Response.Redirect(button != null && button.Equals(btnContinue)
                                      ? "AddCategoryNews.aspx"
                                      : "managecategorynews.aspx");
            }
        }
    }
}