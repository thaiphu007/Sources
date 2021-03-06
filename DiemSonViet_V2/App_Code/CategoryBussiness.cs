﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryBussiness
/// </summary>
public class CategoryBussiness
{
	public CategoryBussiness()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Category> GetAll()
    {

        List<Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.Categories select c).ToList();
        }
        return list;

    }
    public static List<Category> GetParents(){
    
        List<Category> list=null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())        {
             list = (from c in db.Categories where c.ParentId == null && (c.Hidden==null || c.Hidden==false) select c).ToList();
        }
        return list;

    }
    public static List<Category> GetChilds(int? ParentId)
    {

        List<Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.Categories where c.ParentId == ParentId && (c.Hidden == null || c.Hidden == false) select c).ToList();
        }
        return list;

    }
    public static List<Category> GetChilds()
    {

        List<Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.Categories where c.ParentId !=null select c).ToList();
        }
        return list;

    }
    public static Category GetInfo(int Id)
    {

        Category Info= null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.Categories where c.Id == Id select c).FirstOrDefault();
        }
        return Info;

    }
    public static int Save(Category Info)
    
    {
        int Id = -1;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var cate = (from c in db.Categories where c.Id == Info.Id select c).FirstOrDefault();
            if (cate != null)
            {
                cate.CateName = Info.CateName;
                cate.DisplayOrder = Info.DisplayOrder;
                cate.ParentId = Info.ParentId;
                cate.Hidden = Info.Hidden;
            }
            else
                db.Categories.InsertOnSubmit(Info);
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
            var list = from c in db.Categories where Ids.Contains(c.Id.ToString()) select c;
            db.Categories.DeleteAllOnSubmit(list);
            db.SubmitChanges();
        }
        
    }

    // v2

    public static List<tbl_Category> GetAll_V2()
    {

        List<tbl_Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_Categories select c).ToList();
        }
        return list;

    }
    public static List<tbl_Category> GetParents_V2()
    {

        List<tbl_Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_Categories where c.ParentId == null && (c.Hidden == null || c.Hidden == false) select c).ToList();
        }
        return list;

    }
    public static List<tbl_Category> GetChilds_V2(int? ParentId)
    {

        List<tbl_Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_Categories where c.ParentId == ParentId && (c.Hidden == null || c.Hidden == false) select c).ToList();
        }
        return list;

    }
    public static List<tbl_Category> GetChilds_V2()
    {

        List<tbl_Category> list = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            list = (from c in db.tbl_Categories where c.ParentId != null select c).ToList();
        }
        return list;

    }
    public static tbl_Category GetInfo_V2(int Id)
    {

        tbl_Category Info = null;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            Info = (from c in db.tbl_Categories where c.Id == Id select c).FirstOrDefault();
        }
        return Info;

    }
    public static int Save_V2(tbl_Category Info)
    {
        int Id = -1;
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var cate = (from c in db.tbl_Categories where c.Id == Info.Id select c).FirstOrDefault();
            if (cate != null)
            {
                cate.CateName = Info.CateName;
                cate.DisplayOrder = Info.DisplayOrder;
                cate.ParentId = Info.ParentId;
                cate.Hidden = Info.Hidden;
            }
            else
                db.tbl_Categories.InsertOnSubmit(Info);
            db.SubmitChanges();
            Id = Info.Id;
        }
        return Id;
    }
    public static void Delete_V2(string ListId)
    {
        string[] Ids = ListId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        using (DiemSonVietDBDataContext db = new DiemSonVietDBDataContext())
        {
            var list = from c in db.tbl_Categories where Ids.Contains(c.Id.ToString()) select c;
            db.tbl_Categories.DeleteAllOnSubmit(list);
            db.SubmitChanges();
        }

    }


}
