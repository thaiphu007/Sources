using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;
using LinqToExcel;
using KhoiThi = LinqToExcel.KhoiThi;
using Province = LinqToExcel.Province;

namespace KhaoSatHSSV
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private KHAOSATDataContext db = new KHAOSATDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            string filename = @"C:\Users\user\Downloads\Thong tin truong Tinh - THPT.xlsx";

            ExcelProvider provider = ExcelProvider.Create(filename);
            //foreach (Province per in (from p in provider.GetSheet<Province>() select p))
            //{
            //    if (!string.IsNullOrEmpty(per.Tinh))
            //    {
            //        var province = new Classes.DB.Province
            //                           {
            //                               Code = per.Ma,
            //                               ProvinceName = per.Tinh
            //                           };
            //        db.Provinces.InsertOnSubmit(province);
            //        db.SubmitChanges();

            //    }
            //}
            //foreach (KhoiThi per in (from p in provider.GetSheet<KhoiThi>() select p))
            //{
            //    if (!string.IsNullOrEmpty(per.Mon2))
            //    {
            //        Response.Write(string.Format("{0}-{1}-{2}-{3}<br>",per.Khoi,per.Mon1,per.Mon2,per.Mon3));
            //        var khoithi = new Classes.DB.KhoiThi
            //                          {
            //                              Khoi = per.Khoi,
            //                              Mon1 = per.Mon1,
            //                              Mon2 = per.Mon2,
            //                              Mon3 = per.Mon3

            //                          };
            //        db.KhoiThis.InsertOnSubmit(khoithi);
            //        db.SubmitChanges();
            //    }
            //}
            //var list = (from p in provider.GetSheet<THPT>() select p);
            ////Response.Write(list.Count());
            ////Response.End();
            //foreach (THPT per in list)
            //{
            //    if (!string.IsNullOrEmpty(per.TenTruong))
            //    {
            //        Response.Write(string.Format("{0}-{1}-{2}-{3}-<br>", per.KhuVuc, per.TenTruong, per.MaTruong, per.DiaChi));
            //        var truong = new Classes.DB.TruongTHPT
            //                          {
            //                              MaTinh = Commons.TryParseInt(per.MaTinh??"0"),
            //                              MaTruong = Commons.TryParseInt(per.MaTruong??"0"),
            //                              TenTruong = per.TenTruong??string.Empty,
            //                              DiaChi = per.DiaChi??string.Empty,
            //                              KhuVuc = per.KhuVuc??string.Empty
            //                          };
            //        db.TruongTHPTs.InsertOnSubmit(truong);
            //        db.SubmitChanges();
            //    }
            //}
            //var list = (from p in provider.GetSheet<TruongDHCD>() select p);
            ////Response.Write(list.Count());
            ////Response.End();
            //foreach (TruongDHCD per in list)
            //{
            //    if (!string.IsNullOrEmpty(per.TenTruong))
            //    {
            //        Response.Write(string.Format("{0}-{1}<br>", per.TenTruong, per.MaTruong));
            //        var truong = new Classes.DB.College()
            //        {
            //            MaTruong = per.MaTruong??string.Empty,
            //            TenTruong = per.TenTruong,
            //            CapBac = per.TenTruong.ToLower().Contains("CAO ĐẲNG".ToLower())?2:1
            //        };
            //        db.Colleges.InsertOnSubmit(truong);
            //        db.SubmitChanges();
            //    }
            //}
        }
        public override void Dispose()
        {
            base.Dispose();
           // db.Dispose();
        }
    }
}