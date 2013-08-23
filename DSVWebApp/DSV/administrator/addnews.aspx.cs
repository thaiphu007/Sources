using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSV.administrator
{
    public partial class addnews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }
        private void LoadCategory()
        {
            ddlCategory.DataSource = CategoryBussiness.GetAllCategoryNews(false);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField= "Id";
            ddlCategory.DataBind();
        }

        private void LoadData()
        {
            LoadCategory();
            imgIcon.Visible = false;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                try
                {
                    Convert.ToInt32(Request["id"]);
                    hdID.Value = Request["id"];
                    New Info = ContentPagesBussiness.GetInfo_News(Convert.ToInt32(Request["id"]));
                    DisplayInfo(Info);
                }
                catch { }
            }
        }

        private void DisplayInfo(New Info)
        {
            if (Info != null)
            {
                
                hdID.Value = Info.Id.ToString();
                txtTitle.Text = Info.ArTitle;
                txtShortContent.Value = Info.ArSummary;
                txtBody.Value = Info.ArContent;
                txtMetaTitle.Text = Info.MetaTitle;
                txtKeywords.Text = Info.MetaKeyword;
                txtDescriptions.Text = Info.MetaDesc;
                chkPublish.Checked = Info.IsPublished;
                LoadImg(Info.ImageDefault);
                if (Info.CateId != null && ddlCategory.Items.FindByValue(Info.CateId.ToString()) != null)
                {
                    hdCateID.Value = Info.CateId.Value.ToString();
                    ddlCategory.Items.FindByValue(Info.CateId.ToString()).Selected = true;
                }
            }
        }

        private void LoadImg(string Img)
        {

            if (File.Exists(string.Format("{0}uploads/images/{1}", Server.MapPath("~/"), Img)))
            {
                imgIcon.Visible = true;
                imgIcon.ImageUrl = string.Format("~/uploads/images/{0}", Img);
            }
            else if(!string.IsNullOrEmpty(Img)){
                imgIcon.Visible = true;
                imgIcon.ImageUrl = Img;
            }

        }
        private string GetImg()
        {
            string FileName = File.Exists(string.Format("{0}uploads/images/{1}", Server.MapPath("~/"), fUpiCon.FileName)) ? string.Format("{0}_{1}", DateTime.Now.Ticks.ToString(), fUpiCon.FileName) : fUpiCon.FileName;
            fUpiCon.SaveAs(string.Format("{0}uploads/images/{1}", Server.MapPath("~/"), FileName));
            return FileName;
        }


        private New GetNews()
        {
            var Info = new New
                           {
                               ArTitle = txtTitle.Text,
                               ArSummary = txtShortContent.Value,
                               ArContent = txtBody.Value,
                               IsPublished = chkPublish.Checked,
                               MetaTitle = txtMetaTitle.Text,
                               MetaKeyword =
                                   txtKeywords.Text.Trim().Length > 500
                                       ? txtKeywords.Text.Trim().Substring(0, 500)
                                       : txtKeywords.Text.Trim(),
                               MetaDesc =
                                   txtDescriptions.Text.Trim().Length > 500
                                       ? txtDescriptions.Text.Trim().Substring(0, 500)
                                       : txtDescriptions.Text.Trim(),
                               ImageDefault = fUpiCon.HasFile ? GetImg() : txturlIcon.Text,
                               CateId = Convert.ToInt32(ddlCategory.SelectedValue)
                           };
            if (!string.IsNullOrEmpty(hdID.Value.Trim()))
                Info.Id = Convert.ToInt32(hdID.Value);
            return Info;
        }

        private bool CheckValid()
        {
            bool isValid = true;
            string ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                ErrorMessage = Resources.ResourceMessage.ERR_CONTENT_TITILE;
                isValid = false;
            }
            else if (string.IsNullOrEmpty(txtShortContent.Value.Trim()))
            {
                ErrorMessage = Resources.ResourceMessage.ERR_SHORT_CONTENT;
                isValid = false;
            }

            lblError.Text = ErrorMessage;
            return isValid;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Equals(btnBack))
                Response.Redirect("managenews.aspx");
            if (CheckValid())
            {
                ContentPagesBussiness.Save_News(GetNews());
                if (button != null && button.Equals(btnContinue))
                    Response.Redirect("addnews.aspx");
                else
                    Response.Redirect("managenews.aspx");
            }
        }
    }
}