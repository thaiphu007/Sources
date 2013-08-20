using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class usercontrols_ucTopSlide : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadImages();
    }
    private void LoadImages()
    {

        string[] files = Directory.GetFiles(Server.MapPath("~/") + Contants.IMAGES_TOP);
        for (int i=0;i<files.Count();i++)
            files[i] = Contants.SITE_NAME + files[i].Replace(Server.MapPath("~/"), "");
        rptSlide.DataSource = files;
        rptSlide.DataBind();

    }
}