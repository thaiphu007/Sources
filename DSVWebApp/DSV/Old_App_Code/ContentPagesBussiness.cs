using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSV
{
/// <summary>
/// Summary description for ContentPagesBussiness
/// </summary>
public class ContentPagesBussiness
{
	public ContentPagesBussiness()
	{
    }

    public static List<ContentPage> GetAll()
    {

        List<ContentPage> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.ContentPages where c.CateId ==null select c).ToList();
        }
        return list;

    }

    public static List<ContentPage> GetContentHomePage()
    {

        List<ContentPage> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.ContentPages where c.IsHomePage==true && (c.Hidden==false || c.Hidden==null) select c).ToList();
        }
        return list;

    }    

    public static ContentPage GetContentByCateId(int? CateId)
    {

        ContentPage Info = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info= (from c in db.ContentPages where c.CateId== CateId select c).FirstOrDefault();
        }
        return Info;

    }

    public static ContentPage GetInfo(int Id)
    {

        ContentPage Info= null;
        
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.ContentPages where c.Id == Id select c).FirstOrDefault();
        }
        return Info;

    }

    public static string GetInfo(string keyword)
    {

        ContentPage Info = null;

        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.ContentPages where c.ContentName.Trim().ToLower() == keyword.Trim().ToLower() select c).FirstOrDefault();
        }
        return Info==null?string.Empty:Info.Contents;

    }

    public static int Save(ContentPage Info)
    
    {
        int Id = -1;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var ct = (from c in db.ContentPages where c.Id == Info.Id select c).FirstOrDefault();
            if (ct != null)
            {
                ct.ContentName = Info.ContentName;
                ct.ContentTitle = Info.ContentTitle;
                ct.ShortContent = Info.ShortContent;
                ct.Contents = Info.Contents;
                ct.LinkInContent = Info.LinkInContent;
                ct.Hidden = Info.Hidden;
                ct.MetaTitle = Info.MetaTitle;
                ct.MetaKeywords = Info.MetaKeywords;
                ct.MetaDescriptions = Info.MetaDescriptions;                
                if(!string.IsNullOrEmpty(Info.Icon))
                    ct.Icon = Info.Icon;
                ct.CateId = Info.CateId;
                ct.IsHomePage = Info.IsHomePage;
            }
            else
                db.ContentPages.InsertOnSubmit(Info);
           db.SubmitChanges();
           Id = Info.Id;
        }
        return Id;
    }

    public static void Delete(string ListId)
    {
        string[] Ids = ListId.Split(new  char[]{','}, StringSplitOptions.RemoveEmptyEntries);
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var list = from c in db.ContentPages where Ids.Contains(c.Id.ToString()) select c;
            db.ContentPages.DeleteAllOnSubmit(list);
            db.SubmitChanges();
        }
        
    }

    // V2

    public static List<tbl_ContentPage> GetAll_V2()
    {

        List<tbl_ContentPage> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_ContentPages where c.CateId != null && c.IsHomePage==true select c).ToList();
        }
        return list;

    }

    public static List<tbl_ContentPage> GetContentHomePage_V2()
    {

        List<tbl_ContentPage> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_ContentPages where c.IsHomePage == true && (c.Hidden == false || c.Hidden == null) select c).ToList();
        }
        return list;

    }

    public static tbl_ContentPage GetContentByCateId_V2(int? CateId)
    {

        tbl_ContentPage Info = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.tbl_ContentPages where c.CateId == CateId select c).FirstOrDefault();
        }
        return Info;

    }

    public static tbl_ContentPage GetInfo_V2(int Id)
    {

        tbl_ContentPage Info = null;

        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.tbl_ContentPages where c.Id == Id select c).FirstOrDefault();
        }
        return Info;

    }
    public static New GetInfo_News(int Id)
    {

        New Info = null;

        using (var db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.News where c.Id == Id select c).FirstOrDefault();
        }
        return Info;

    }

    public static string GetInfo_V2(string keyword)
    {

        tbl_ContentPage Info = null;

        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.tbl_ContentPages where c.ContentName.Trim().ToLower() == keyword.Trim().ToLower() select c).FirstOrDefault();
        }
        return Info == null ? string.Empty : Info.Contents;

    }

    public static int Save_V2(tbl_ContentPage Info)
    {
        int Id = -1;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var ct = (from c in db.tbl_ContentPages where c.Id == Info.Id select c).FirstOrDefault();
            if (ct != null)
            {
                ct.ContentName = Info.ContentName;
                ct.ContentTitle = Info.ContentTitle;
                ct.ShortContent = Info.ShortContent;
                ct.Contents = Info.Contents;
                ct.LinkInContent = Info.LinkInContent;
                ct.Hidden = Info.Hidden;
                ct.MetaTitle = Info.MetaTitle;
                ct.MetaKeywords = Info.MetaKeywords;
                ct.MetaDescriptions = Info.MetaDescriptions;
                if (!string.IsNullOrEmpty(Info.Icon))
                    ct.Icon = Info.Icon;
                ct.CateId = Info.CateId;
                ct.IsHomePage = Info.IsHomePage;
            }
            else
                db.tbl_ContentPages.InsertOnSubmit(Info);
            db.SubmitChanges();
            Id = Info.Id;
        }
        return Id;
    }
    public static int Save_News(New Info)
    {
        int Id = -1;
        using (var db = new DiemSonVietDBDataContext())
        {
            var ct = (from c in db.News where c.Id == Info.Id select c).FirstOrDefault();
            if (ct != null)
            {
                ct.ArTitle = Info.ArTitle;
                ct.ArSummary = Info.ArSummary;
                ct.ArContent = Info.ArContent;
                ct.CateId = Info.CateId;
                ct.IsPublished = Info.IsPublished;
                ct.CreateDated = DateTime.Now;
                ct.MetaTitle = Info.MetaTitle;
                ct.MetaKeyword = Info.MetaKeyword;
                ct.MetaDesc = Info.MetaDesc;
                if (!string.IsNullOrEmpty(Info.ImageDefault))
                    ct.ImageDefault = Info.ImageDefault;
                ct.CateId = Info.CateId;
                ct.PublishDated = DateTime.Now;
            }
            else
            {
                Info.CreateDated = DateTime.Now;
                Info.PublishDated = DateTime.Now;
                db.News.InsertOnSubmit(Info);
            }
            db.SubmitChanges();
            Id = Info.Id;
        }
        return Id;
    }

    public static void Delete_V2(string ListId)
    {
        string[] Ids = ListId.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        using (var db = new DiemSonVietDBDataContext())
        {
            var list = from c in db.tbl_ContentPages where Ids.Contains(c.Id.ToString()) select c;
            db.tbl_ContentPages.DeleteAllOnSubmit(list);
            db.SubmitChanges();
        }

    }
	
}



}
