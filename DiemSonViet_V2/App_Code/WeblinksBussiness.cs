using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WeblinksBussiness
/// </summary>
public class WeblinksBussiness
{
	public WeblinksBussiness()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static List<WebLink> GetAll()
    {

        List<WebLink> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            
            list = (from c in db.WebLinks select c).ToList();
        }
        return list;

    }
   
    public static WebLink GetInfo(int Id)
    {

        WebLink Info = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from l in db.WebLinks where l.Id == Id select l).FirstOrDefault();
        }
        return Info;

    }
    public static int Save(WebLink Info)
    {
        int Id = -1;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var link = (from l in db.WebLinks where l.Id == Info.Id select l).FirstOrDefault();
            if (link != null)
            {
                link.Links = Info.Links;
                link.DisplayOrder = Info.DisplayOrder;
                link.LinkName = Info.LinkName;
            }
            else
                db.WebLinks.InsertOnSubmit(Info);
            db.SubmitChanges();
            Id = Info.Id;
        }
        return Id;
    }

    public static void Delete(string ListId)
    {
        string[] Ids = ListId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var list = from c in db.WebLinks where Ids.Contains(c.Id.ToString()) select c;
            db.WebLinks.DeleteAllOnSubmit(list);
            db.SubmitChanges();
        }

    }
}
