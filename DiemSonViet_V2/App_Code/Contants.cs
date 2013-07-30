using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Contants
/// </summary>
public class Contants
{
	public Contants()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string USERNAME = ConfigurationManager.AppSettings["username"].ToString();
    public static string PASSWORD = ConfigurationManager.AppSettings["password"].ToString();
    public static string CODE = ConfigurationManager.AppSettings["code"].ToString();
    public static string IMAGES_TOP = ConfigurationManager.AppSettings["imagespath_top"].ToString();
    public static string IMAGES_BOTTOM = ConfigurationManager.AppSettings["imagespath_bottom"].ToString();
    public static string SITE_NAME = ConfigurationManager.AppSettings["sitename"].ToString();
}
