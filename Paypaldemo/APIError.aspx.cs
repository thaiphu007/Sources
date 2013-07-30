using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.paypal.sdk.util;

public partial class APIError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["errorresult"] != null)
            {
                NVPCodec decoder = new NVPCodec();
                decoder = (NVPCodec)Session["errorresult"];

                string res = "<center>";
                res = res + "<font size=2 color=black face=Verdana><b>" + "PayPal API Error" + "</b></font>";
                res = res + "<br>";
                res = res + "<br>";


                res = res + "<b>" + "A PayPal API has returned an error!" + "</b><br>";

                res = res + "<br>";

                res = res + "<table width=400 class=api>";


                for (int i = 0; i < decoder.Keys.Count; i++)
                {
                    res = res + "<tr><td class=field> " + decoder.Keys[i].ToString() + ":</td>";
                    res = res + "<td>" + decoder.GetValues(i)[0] + "</td>";
                    res = res + "</tr>";
                    res = res + "<tr>";
                }

                res = res + "</table>";
                res = res + "</center>";

                Response.Write(res);

                Session.Remove("errorresult");
            }
        }
    }
}
