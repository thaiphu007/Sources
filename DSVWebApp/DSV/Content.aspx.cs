using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DSV;

public partial class Content : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadContent();
    }
    private void LoadContent()
    {
        int Id = 0;
        Int32.TryParse(Request.QueryString["id"],out Id);
        tbl_ContentPage Info = ContentPagesBussiness.GetContentByCateId_V2(Id);
        if (Info != null)
        {
            liContent.Text = Info.Contents;
            if (Info != null)
            {                
                this.Title = Resources.ResourceDefaultValue.METATITLE.ToString() + (string.IsNullOrEmpty(Info.MetaTitle) ? "" : " - " + Server.HtmlEncode(Info.MetaTitle));
                HtmlHead headTag = (HtmlHead)Page.Header;

                // Add a Description meta tag
                HtmlMeta metaTag = new HtmlMeta();
                metaTag.Name = "Description";
                metaTag.Content = string.IsNullOrEmpty(Info.MetaDescriptions) ? Resources.ResourceDefaultValue.METADESCRIPTION.ToString() : Server.HtmlEncode(Info.MetaDescriptions);
                headTag.Controls.Add(metaTag);

                // Add a Keywords meta tag
                metaTag = new HtmlMeta();
                metaTag.Name = "Keywords";
                metaTag.Content = string.IsNullOrEmpty(Info.MetaKeywords) ? Resources.ResourceDefaultValue.METAKEYWORD.ToString() : Server.HtmlEncode(Info.MetaKeywords);
                headTag.Controls.Add(metaTag);

            }
        }
    }
}