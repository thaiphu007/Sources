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
using Nhom_Nganh = LinqToExcel.Nhom_Nganh;
using Province = LinqToExcel.Province;

namespace KhaoSatHSSV
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private KHAOSATDataContext db = new KHAOSATDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            //string filename = @"C:\Users\user\Downloads\Thong tin truong Tinh - THPT.xlsx";

            //ExcelProvider provider = ExcelProvider.Create(filename);
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
            Import();
        }
       
        private void Import()
        {
            string filename = @"C:\Users\user\Downloads\Linh vuc nghe nghiep -Change-- Nhom nganh_OK (1).xlsx";

            ExcelProvider provider = ExcelProvider.Create(filename);
            var list = (from p in provider.GetSheet<Nhom_Nganh>() select p);
            //Response.Write(list.Count());
            //Response.End();
            string matruong = string.Empty;
            foreach (Nhom_Nganh per in list)
            {
                if (!string.IsNullOrEmpty(per.MaNhom))
                {
                    //Response.Write(string.Format("{9}=>{0}=>{1}=>{2}=>{3}=>{4}=>{5}=>{6}=>{7}=>{8}<br>", per.TenTruong, per.DiaChi, per.WEBSITE, per.MaTruong, per.MaNganh, per.TenNGanh, per.KhoiThi, per.LoaiTruong, per.GhiChu, matruong));


                    //var dhnganh = new Classes.DB.DHCD_Nganh()
                    //{

                    //    MaTruong = matruong,
                    //    MaNganh = per.MaNganh,
                    //    KhoiThi = per.KhoiThi ?? string.Empty,
                    //    TuyenSinh = true,
                    //    NamTuyenSinh = DateTime.Now.Year.ToString()
                    //};
                    //db.DHCD_Nganhs.InsertOnSubmit(dhnganh);
                    //db.SubmitChanges();

                    //Response.Write(string.Format("{0}=>{1}<br/>",per.MaNganh,per.TenNganh));

                    //var group = new Classes.DB.Nganh()
                    //{
                    //    Ma = per.MaNganh.Trim(),
                    //    TenNganh = per.TenNganh.Trim()
                    //};
                    //db.Nganhs.InsertOnSubmit(group);
                    //db.SubmitChanges();
                    //var nhomnganh =
                    //    (from n in db.NhomNganhs where n.Ma.Trim() == per.MaNganh.Trim().Substring(0, 8) select n).
                    //        FirstOrDefault();
                    //if (nhomnganh != null)
                    //{
                    //    var group_nganh = new Classes.DB.Nhom_Nganh()
                    //    {
                    //        MaNganh = group.Id,
                    //        MaNhomNganh = nhomnganh.Id
                    //    };
                    //    db.Nhom_Nganhs.InsertOnSubmit(group_nganh);
                    //    db.SubmitChanges();
                    //}

                    var group = new Classes.DB.NhomNganh()
                    {
                        Ma = per.MaNhom,
                        TenNhom = per.TenNhom
                    };
                    db.NhomNganhs.InsertOnSubmit(group);
                    db.SubmitChanges();
                }
                //else if (!string.IsNullOrEmpty(per.MaTruong))
                //{

                //    Response.Write(string.Format("{0}=>{1}=>{2}=>{3}=>{4}=>{5}=>{6}=>{7}=>{8}<br>", per.TenTruong, per.DiaChi, per.WEBSITE, per.MaTruong, per.MaNganh, per.TenNGanh, per.KhoiThi, per.LoaiTruong, per.GhiChu));
                  
                //    var college = new Classes.DB.College()
                //    {
                //        TenTruong = per.TenTruong,
                //        MaTruong = per.MaTruong,
                //        DiaChi = per.DiaChi??string.Empty,
                //        WebSite = per.WEBSITE??string.Empty,
                //        GhiChu = per.GhiChu??string.Empty,
                //        LoaiTruong = per.LoaiTruong!=null && per.LoaiTruong.Trim()=="CL"?1:0,
                //        CapBac = 2,
                //        HienThi = true
                //    };
                //    db.Colleges.InsertOnSubmit(college);
                //    db.SubmitChanges();
                //    matruong = per.MaTruong;
                //}
            }
        }
    }
}