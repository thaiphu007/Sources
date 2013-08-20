using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Commons
/// </summary>
public class Commons
{
	public Commons()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool isValidEmail(string inputEmail)
    {
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }

    public static string ReadFromFile(string path, bool isRelativePath)
    {
        if (isRelativePath)
            path = HttpContext.Current.Server.MapPath(path);
        
        System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
        System.IO.StreamReader reader = new System.IO.StreamReader(stream);

        string file = "";
        try
        {
            file = reader.ReadToEnd();
        }
        catch
        {
        }
        reader.Close();
        stream.Close();
        return file;
    }

    public static bool SendMail(string sSenderName, string sSenderEmail, string sSubject, string sTo, string sMessage, bool bIsHtml, string sBCC, bool EnableSsl)
    {
        bool flag = false;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

        try
        {
            message.Body = sMessage;
            message.BodyEncoding = System.Text.Encoding.UTF8;            
            System.Net.Mail.MailAddress addrFrom = new System.Net.Mail.MailAddress(sSenderEmail, sSenderName);
            message.From = addrFrom;

            if (!string.IsNullOrEmpty(sBCC))
            {
                foreach (string strBcc in sBCC.Split(','))
                {
                    message.Bcc.Add(strBcc);
                }

            }

            if (sTo != string.Empty)
            {
                foreach (string strToEmail in sTo.Split(','))
                {
                    message.To.Add(strToEmail);
                }

            }

            message.IsBodyHtml = bIsHtml;
            message.Subject = sSubject;
            client.EnableSsl = EnableSsl;
            try
            {
                client.Send(message);
                flag = true;
            }
            catch (SmtpFailedRecipientsException smtpEx)
            {
                for (int i = 0; i < smtpEx.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = smtpEx.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
                    {
                        System.Threading.Thread.Sleep(5000);
                        client.Send(message);
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
        }
        catch 
        {
            flag = false;

            //throw ex;
        }
        return flag;
    }
    private static readonly string[] VietnameseSigns = new string[]
    {
        "aAeEoOuUiIdDyY ",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ",
        "*&+.^()[]{}$!@~><?,;:'\"|\\/`"
    };

    public static string RemoveSpecialCharacters(string str)
    {
        str = StripTagsRegex(str);
        for (int i = 1; i < VietnameseSigns.Length; i++){
            for (int j = 0; j < VietnameseSigns[i].Length; j++)
                str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
        }
     
        str = str.Replace("  ", " ").Replace(" ", "-");
        return str;

    }
    public static string StripTagsRegex(string source)
    {
        return Regex.Replace(source, "<[^>]*>", string.Empty);
    }

}
