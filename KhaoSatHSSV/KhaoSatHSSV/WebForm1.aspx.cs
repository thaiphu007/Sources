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
       
        private void InsertGroupNganh(int GroupId,string nganhs)
        {
            foreach (var item in nganhs.Split(';'))
            {
                if(!string.IsNullOrEmpty(item))
                {
                    var group = new Classes.DB.Groups_Nganh()
                    {
                        Manganh = item.Trim(),
                        NhomId = GroupId
                    };
                    db.Groups_Nganhs.InsertOnSubmit(group);
                  //  db.SubmitChanges();
                }
            }

        }
        private void Import()
        {
            string filename = @"C:\Users\user\Downloads\Truong_Nganh_Diem chuan_DH_CD_OK (2).xlsx";

            ExcelProvider provider = ExcelProvider.Create(filename);
            var list = (from p in provider.GetSheet<DHCD_Nganha>() select p);
            //Response.Write(list.Count());
            //Response.End();
            string matruong = string.Empty;
            foreach (DHCD_Nganha per in list)
            {
                if (!string.IsNullOrEmpty(per.MaTruong))
                {
                    matruong = per.MaTruong;
                    Response.Write(per.MaTruong + "<br/>");
                    //var dhnganh = new Classes.DB.DHCD_Nganh()
                    //    {

                    //        MaTruong = matruong,
                    //        MaNganh = per.MaNganh,
                    //        KhoiThi = per.KhoiThi ?? string.Empty,
                    //        TuyenSinh = true,
                    //        NamTuyenSinh = DateTime.Now.Year.ToString()
                    //    };
                    //    db.DHCD_Nganhs.InsertOnSubmit(dhnganh);
                    //    db.SubmitChanges();
                }
                else if (!string.IsNullOrEmpty(matruong) && !string.IsNullOrEmpty(per.MaNganh))
                {
                    var dhnganh = (from d in db.DHCD_Nganhs
                                   where d.MaNganh != null && d.MaNganh.Trim() == per.MaNganh.Trim() && d.MaTruong.ToLower().Trim() == matruong.ToLower().Trim()
                                   select d).FirstOrDefault();
                    if (dhnganh != null)
                    {
                        dhnganh.NamTuyenSinh =string.IsNullOrEmpty(per.NV1)?"0": per.NV1.Replace(",", ";");
                        if (!string.IsNullOrEmpty(per.NV2))
                            dhnganh.NamTuyenSinh += ";" + (string.IsNullOrEmpty(per.NV2) ? "0" : per.NV2.Replace(",", ";"));
                        if (string.IsNullOrEmpty(dhnganh.NamTuyenSinh))
                            dhnganh.NamTuyenSinh = "0";
                        db.SubmitChanges();
                    }

                    Response.Write(matruong + "=> " + per.MaNganh + "=> " + per.NV1 + "=> " + per.NV2 + "<br/>");
                }


            }
        }
    }
}