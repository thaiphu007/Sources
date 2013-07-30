using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using com.paypal.sdk.services;
using com.paypal.sdk.profiles;
using com.paypal.sdk.util;
using com.paypal.sdk.core;

using ASPDotNetSamples.AspNet;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPDotNetSamples.AspNet.Constants.is3token = true;
        Session["stage"] = ASPDotNetSamples.AspNet.Constants.ENVIRONMENT;
        SetProfile.SessionProfile = SetProfile.CreateAPIProfile(ASPDotNetSamples.AspNet.Constants.API_USERNAME, ASPDotNetSamples.AspNet.Constants.API_PASSWORD, ASPDotNetSamples.AspNet.Constants.API_SIGNATURE, "", "", ASPDotNetSamples.AspNet.Constants.ENVIRONMENT, ASPDotNetSamples.AspNet.Constants.SUBJECT, ASPDotNetSamples.AspNet.Constants.OAUTH_SIGNATURE, ASPDotNetSamples.AspNet.Constants.OAUTH_TOKEN, ASPDotNetSamples.AspNet.Constants.OAUTH_TIMESTAMP);

    }
    protected void PayButton_Click1(object sender, EventArgs e)
    {
        try
        {
            com.paypal.sdk.services.NVPCallerServices caller = PayPalAPI.PayPalAPIInitialize();
            NVPCodec encoder = new NVPCodec();
            encoder["METHOD"] = "CreateRecurringPaymentsProfile";
            encoder["AMT"] = amount.Value;
            encoder["CREDITCARDTYPE"] = creditCardType.SelectedItem.Value;
            encoder["ACCT"] = creditCardNumber.Value;
            encoder["EXPDATE"] = expdate_month.Value.ToString() + expdate_year.Value;
            encoder["CVV2"] = cvv2Number.Value;
            encoder["FIRSTNAME"] = firstName.Value;
            encoder["LASTNAME"] = lastName.Value;
            encoder["STREET"] = address1.Value;
            encoder["CITY"] = city.Value;
            encoder["STATE"] = state.Value;
            encoder["ZIP"] = zip.Value;
            encoder["COUNTRYCODE"] = "US";
            encoder["CURRENCYCODE"] = currency.Value;
            string pdates = pYear.Value + "-" + pMonth.Value + "-" + pDate.Value + "T0:0:0";//Date format from server expects Ex: 2006-9-6T0:0:0;
            encoder["PROFILESTARTDATE"] = pdates;
            encoder["BILLINGPERIOD"] = BillingPeriod.Value;
            encoder["BILLINGFREQUENCY"] = BillingFrequency.Value;
            encoder["TOTALBILLINGCYCLES"] = totalBillingCycles.Value;
            encoder["DESC"] = ProfileDescription.Value;
            encoder["INITAMT"] = amount.Value;
         


            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = caller.Call(pStrrequestforNvp);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);

            string strAck = decoder["ACK"];
            if (strAck != null && (strAck == "Success" || strAck == "SuccessWithWarning"))
            {
                Session["result"] = decoder;
                string pStrResQue = "API=" + "Create Recurring Payments Profile";
                Response.Redirect("Response.aspx?" + pStrResQue);
            }
            else
            {
                Session["errorresult"] = decoder;
                string pStrResQue = "API=" + "Error Detail ";
                Response.Redirect("/Paypaldemo/APIError.aspx?" + pStrResQue);
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
  
}
