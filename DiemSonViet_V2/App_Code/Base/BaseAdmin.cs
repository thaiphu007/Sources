using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BaseAdmin
/// </summary>
public class BaseAdmin:MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (Session["UserLogin"] == null)
            Response.Redirect("login.aspx");
        
    }
}
