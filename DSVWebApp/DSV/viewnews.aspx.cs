using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DSV
{
    public partial class viewnews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadContent();
        }
        private void LoadContent()
        {
            int Id = 0;
            Int32.TryParse(Request.QueryString["id"], out Id);
            New Info = ContentPagesBussiness.GetInfo_News(Id);
            if (Info != null)
            {
                liTitle.Text = Info.ArTitle;
                liContent.Text = Info.ArContent;

                Title = string.IsNullOrEmpty(Info.MetaTitle)?Resources.ResourceDefaultValue.METATITLE : Server.HtmlEncode(Info.MetaTitle);

                    HtmlHead headTag = Page.Header;
                    // Add a Description meta tag
                    var metaTag = new HtmlMeta
                                      {
                                          Name = "Description",
                                          Content =
                                              string.IsNullOrEmpty(Info.MetaDesc)
                                                  ? Resources.ResourceDefaultValue.METADESCRIPTION
                                                  : Server.HtmlEncode(Info.MetaDesc)
                                      };
                    headTag.Controls.Add(metaTag);

                    // Add a Keywords meta tag
                    metaTag = new HtmlMeta
                                  {
                                      Name = "Keywords",
                                      Content =
                                          string.IsNullOrEmpty(Info.MetaKeyword)
                                              ? Resources.ResourceDefaultValue.METAKEYWORD
                                              : Server.HtmlEncode(Info.MetaKeyword)
                                  };
                    headTag.Controls.Add(metaTag);
                
            }
        }
    }
}