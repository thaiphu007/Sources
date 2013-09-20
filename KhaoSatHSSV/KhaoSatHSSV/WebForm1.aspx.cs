using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KhaoSatHSSV
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.futabuslines.com.vn/Router.aspx");
            request.CookieContainer = new CookieContainer();

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();



            // Print the properties of each cookie. 
            foreach (Cookie cook in response.Cookies)
            {
                Response.Write("Cookie:");
                Response.Write(string.Format("{0} = {1}", cook.Name, cook.Value));
                Response.Write(string.Format("Domain: {0}", cook.Domain));
                Response.Write(string.Format("Path: {0}", cook.Path));
                Response.Write(string.Format("Port: {0}", cook.Port));
                Response.Write(string.Format("Secure: {0}", cook.Secure));

                Response.Write(string.Format("When issued: {0}", cook.TimeStamp));
                Response.Write(string.Format("Expires: {0} (expired? {1})",
                                             cook.Expires, cook.Expired));
                Response.Write(string.Format("Don't save: {0}", cook.Discard));
                Response.Write(string.Format("Comment: {0}", cook.Comment));
                Response.Write(string.Format("Uri for comments: {0}", cook.CommentUri));
                Response.Write(string.Format("Version: RFC {0}", cook.Version == 1 ? "2109" : "2965"));

                // Show the string representation of the cookie.
                Response.Write(string.Format("String: {0}", cook.ToString()));

            }
        }
    }
}