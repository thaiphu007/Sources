using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class administrator_Login : System.Web.UI.Page
{
    public string ErrorMessage = "<span style='color:red'>Try Again!</span>";
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCode.Attributes.Add("autocomplete", "off");
        if (!IsPostBack)
        {
            if (Request["act"] != null && !string.IsNullOrEmpty(Request["act"]))
                Session["UserLogin"] = null;
                
            ErrorMessage = string.Empty;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["UserLogin"] = null;
        if (txtUserName.Text == Contants.USERNAME &&
            txtPassword.Text == Contants.PASSWORD &&
            txtCode.Text == Contants.CODE)
        {
            Session["UserLogin"] = true;
            ErrorMessage = string.Empty;
            Response.Redirect("default.aspx");
        }
        
    }
}
