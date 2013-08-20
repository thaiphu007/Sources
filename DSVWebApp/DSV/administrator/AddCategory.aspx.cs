using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DSV;

public partial class administrator_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategory();
            LoadData();
        }
    }

    private void LoadData()
    {
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            try
            {
                Convert.ToInt32(Request["id"]);
                hdID.Value = Request["id"];
                tbl_Category Info = CategoryBussiness.GetInfo_V2(Convert.ToInt32(Request["id"]));
                if (Info != null)
                {
                    txtCateName.Text = Info.CateName;
                    txtDisplayOrder.Text = Info.DisplayOrder==null?"":Info.DisplayOrder.ToString();
                    if (Info.ParentId != null && drpCategory.Items.FindByValue(Info.ParentId.ToString()) != null)
                        drpCategory.Items.FindByValue(Info.ParentId.ToString()).Selected = true;
                    else
                        drpCategory.SelectedIndex = 0;
                    chkHidden.Checked = Info.Hidden==null?false:Info.Hidden.Value;
                }
            }
            catch { }
        }
    }

    private void LoadCategory()
    {
        

            drpCategory.DataSource = CategoryBussiness.GetParents_V2();
            drpCategory.DataTextField = "CateName";
            drpCategory.DataValueField = "Id";
            drpCategory.DataBind();
            drpCategory.Items.Insert(0,new ListItem(Resources.ResourceDefaultValue.SELECT_CATE_PARENT,"-1"));
       
    }

    private tbl_Category GetCategory()
    {
        tbl_Category Info = new tbl_Category();
        Info.CateName = txtCateName.Text;
        Info.DisplayOrder = Convert.ToInt32(txtDisplayOrder.Text);
        Info.Hidden = chkHidden.Checked;
        if(drpCategory.SelectedIndex>0)
            Info.ParentId = Convert.ToInt32(drpCategory.SelectedValue);        
        if (!string.IsNullOrEmpty(hdID.Value.Trim()))
            Info.Id = Convert.ToInt32(hdID.Value);
        return Info;
    }

    private bool CheckValid()
    {
        bool isValid= true;
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
            catch {
                ErrorMessage = Resources.ResourceMessage.ERR_DISPLAYORDER;
                isValid = false; 
            }
        }
        lblError.Text = ErrorMessage;
        return isValid;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ((sender as Button).Equals(btnBack))
            Response.Redirect("default.aspx");
        if (CheckValid())
        {
            int Id=CategoryBussiness.Save_V2(this.GetCategory());
            if ((sender as Button).Equals(btnContinue))
                Response.Redirect("AddCategory.aspx");
            else
                Response.Redirect("default.aspx");
        }
    }
   
    
}
