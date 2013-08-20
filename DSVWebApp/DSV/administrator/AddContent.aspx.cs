using System;
using System.Web.UI.WebControls;
using System.IO;
using DSV;

public partial class administrator_AddContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadData();
    }

    private void LoadData()
    {
        imgIcon.Visible = false;
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            try
            {
                Convert.ToInt32(Request["id"]);
                hdID.Value = Request["id"];
                tbl_ContentPage Info = ContentPagesBussiness.GetInfo_V2(Convert.ToInt32(Request["id"]));
                DisplayInfo(Info);
            }
            catch { }
        }
        else if (!string.IsNullOrEmpty(Request["cid"]))
        {
            try
            {
               

                Convert.ToInt32(Request["cid"]);
                hdCateID.Value = Request["cid"];
                tbl_ContentPage Info = ContentPagesBussiness.GetContentByCateId_V2(Convert.ToInt32(Request["cid"]));
                DisplayInfo(Info);
            }
            catch { }
        }
    }

    private void DisplayInfo(tbl_ContentPage Info)
    {
        if (Info != null)
        {
            btnDelete.Visible = true;
            hdID.Value = Info.Id.ToString();
            txtContentName.Text = Info.ContentName;
            txtTitle.Text = Info.ContentTitle;
            txtShortContent.Value = Info.ShortContent;
            txtBody.Value = Info.Contents;
            txtMetaTitle.Text = Info.MetaTitle;
            txtKeywords.Text = Info.MetaKeywords;
            txtDescriptions.Text = Info.MetaDescriptions;
            chkHidden.Checked = Info.Hidden == null ? false : Info.Hidden.Value;
            ckHomePage.Checked = Info.IsHomePage == null ? false : Info.IsHomePage.Value;
            if (Info.CateId != null)
                hdCateID.Value = Info.CateId.Value.ToString();
        }
    }

    private void LoadImg(string Img)
    {
        
        if (File.Exists(Server.MapPath("~/") + "uploads/icons/" + Img))
        {
            imgIcon.Visible = true;
            imgIcon.ImageUrl="~/uploads/icons/" + Img;
        }

    }
    private string GetImg()
    {
        string FileName = string.Empty;
        if (File.Exists(string.Format("{0}uploads/icons/{1}", Server.MapPath("~/"), fUpiCon.FileName)))
            FileName = string.Format("{0}_{1}", DateTime.Now.Ticks.ToString(), fUpiCon.FileName);
        else
            FileName = fUpiCon.FileName;
        fUpiCon.SaveAs(string.Format("{0}uploads/icons/{1}", Server.MapPath("~/"), FileName));
        return FileName;
    }


    private tbl_ContentPage GetContent()
    {
        tbl_ContentPage Info = new tbl_ContentPage();
        Info.ContentName= txtContentName.Text;
        Info.ContentTitle = txtTitle.Text;
        Info.ShortContent = txtShortContent.Value;
        Info.Contents = txtBody.Value;
        Info.IsHomePage = ckHomePage.Checked;
        Info.MetaTitle=txtMetaTitle.Text;
        if (txtKeywords.Text.Trim().Length > 500)
            Info.MetaKeywords = txtKeywords.Text.Trim().Substring(0, 500);
        else
            Info.MetaKeywords = txtKeywords.Text.Trim();
        if (txtDescriptions.Text.Trim().Length > 500)
            Info.MetaDescriptions = txtDescriptions.Text.Trim().Substring(0, 500);
        else
            Info.MetaDescriptions = txtDescriptions.Text.Trim();
        Info.Hidden =chkHidden.Checked;
        if (fUpiCon.HasFile)
            Info.Icon = GetImg();
        else
            Info.Icon = null;
        if (!string.IsNullOrEmpty(hdCateID.Value.Trim()))
            Info.CateId = Convert.ToInt32(hdCateID.Value);
        if (!string.IsNullOrEmpty(hdID.Value.Trim()))
            Info.Id = Convert.ToInt32(hdID.Value);
        return Info;
    }

    private bool CheckValid()
    {
        bool isValid = true;
        string ErrorMessage = string.Empty;
        //if (string.IsNullOrEmpty(txtContentName.Text.Trim()))
        //{
        //    ErrorMessage = Resources.ResourceMessage.ERR_CONTENT_NAME;
        //    isValid = false;
        //}
        //else  
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ContentPagesBussiness.Delete_V2(hdID.Value);
        Response.Redirect("default.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((sender as Button).Equals(btnBack))
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
                Response.Redirect("default.aspx");
            Response.Redirect("cms.aspx");
        }
        if (CheckValid())
        {
            int Id = ContentPagesBussiness.Save_V2(this.GetContent());

            if ((sender as Button).Equals(btnContinue))
                Response.Redirect("AddContent.aspx");
            else
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                    Response.Redirect("default.aspx");
                Response.Redirect("cms.aspx");
            }
        }
    }
   

}
