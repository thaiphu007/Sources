﻿using System;
using System.Collections.Generic;
using DSV;

public partial class usercontrols_SubMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private string _ParentCateName = string.Empty;
    public string PareantCateName
    {
        get { return _ParentCateName; }
        set { _ParentCateName = value; }
    }
    public void LoadSubMenu(List<tbl_Category> list)
    {
        rptSub.DataSource = list;
        rptSub.DataBind();
        
    }
}