using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.paypal.sdk.util;

public partial class Response : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NVPCodec decoder = new NVPCodec();
        decoder = (NVPCodec)Session["result"];

        string res = "<center>";
        res = res + "<font size=2 color=black face=Verdana><b>" + Request.QueryString.Get("API") + "</b></font>";
        res = res + "<br>";
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
        if (Request.QueryString.Get("API") != "Recurring Payments Profile Details")
        {
            res = res + "<a id=RPDetail href='GetRecurringPaymentsProfileDetails.aspx?profileid=" + decoder["PROFILEID"] + "'>Get Recurring Payments Details</a>";
        }
        res = res + "</center>";

        Response.Write(res);
    }
}
