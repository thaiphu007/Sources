using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class TuVanChonNganh : System.Web.UI.Page
    {
        private readonly KHAOSATDataContext db = new KHAOSATDataContext();


       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              
                LoadKhoiThi();
                if (Session["SVID"] != null)
                {
                    var id = (long) Session["SVID"];
                    if (id > 0)
                        LoadData(id);
                    else
                        Response.Redirect("/login.aspx");
                }
                else
                    Response.Redirect("/login.aspx");

            }
        }

        private void LoadData(long svId)
        {

            
            List<GetList_AnswerResult> list = db.GetList_Answer().ToList();
            list = list.Where(t => t.TesterId == 238 || t.TesterId == 520).ToList();
            UpdateTrainingExamples(list,svId);
        }

        private bool checkZero(int testerId)
        {
            var result = false;
            
                var total = (from s in db.Survey_Answers where s.TesterId == testerId select s).Sum(s => s.ChooseLevel);
                result = total == 0;
            
            return result;
        }

        private void checkDefference(int index, GetList_AnswerResult item, ref List<GetList_AnswerResult> list)
        {

            bool IsRemove = false;
            for (int i = index; i < list.Count; i++)
            {
                var temp = list[i];

                foreach (var propertyInfo in temp.GetType()
                               .GetProperties(
                                       BindingFlags.Public
                                       | BindingFlags.Instance))
                {
                    if (propertyInfo.Name != "TesterId")
                    {
                        PropertyInfo pi = item.GetType().GetProperty(propertyInfo.Name);
                        var val1 = pi.GetValue(item, null).ToString();
                        var val2 = propertyInfo.GetValue(temp, null).ToString();
                        if (val1 != val2)
                        {
                            if (propertyInfo.Name == "MaNganh")
                                IsRemove = true;
                            break;
                        }
                    }

                }
                if (IsRemove)
                    list[i].MaNganh = item.MaNganh;
                IsRemove = false;
            }

        }

        private void UpdateTrainingExamples(List<GetList_AnswerResult> list, long svId)
        {
            var testID3 = new ID3();
            for (int i = 1; i <= 54; i++)
            {
                testID3.attributes.Add(string.Format("Q{0}", i.ToString()));
                testID3.staticAtt.Add(string.Format("Q{0}", i.ToString()));
            }

            int index = 0;
            foreach (var item in list)
            {
                checkDefference(index, item, ref list);
                index++;
                if (item.TesterId != null && checkZero(item.TesterId.Value))
                    continue;
                var example = new Example();
                foreach (var propertyInfo in item.GetType()
                                .GetProperties(
                                        BindingFlags.Public
                                        | BindingFlags.Instance))
                {

                    example.AddValue(propertyInfo.GetValue(item, null).ToString());
                }
                testID3.trainingExamples.Add(example);

            }
            testID3.ID3Alg(testID3.trainingExamples, testID3.attributes, -1);
            
            //   Response.Write(testID3.glDtID3Alg.GetRules());
            var GetList_AnswerResult=db.GetList_Answer_By_SinhVien(svId).FirstOrDefault();
            LoadNganh();
            string result=testID3.glDtID3Alg.GetNganh(GetList_AnswerResult);
            if (result != null)
            {
                var info = db.Nganhs.FirstOrDefault(n => n.Ma.Trim() == result.Trim());
                //LoadTruong(result);
                Session["maNganh"] = result.Trim();
                lblTitle.Text = info != null ? string.Format(" Bạn phù hợp với ngành: {0}", info.TenNganh) : "Không có ngành phù hợp với kết quả khảo sát của Bạn";
                if (info == null)
                    LoadNganh();
            }
            else
            {
                lblTitle.Text = "Không có ngành phù hợp với kết quả khảo sát của Bạn";
                LoadNganh();
            }

        }

        private void LoadNganh( )
        {
            tbListNganh.Visible = true;
            string[] groups = Request.QueryString["gr"].Split(';');
            using (var db1 = new KHAOSATDataContext())
            {
                var list = (from n in db.Groups_Nganhs
                            join g in db.Nganhs on n.Manganh.Trim() equals g.Ma.Trim()
                            where
                                (n.NhomId == Commons.TryParseInt(groups[0])) || (n.NhomId == Commons.TryParseInt(groups[1]))
                            select new {TN=g.TenNganh,MN=g.Ma}).Distinct();
                rptNganh.DataSource = list;
                rptNganh.DataBind();
            }
        }

        private void LoadKhoiThi()
        {
            //var listtruong = from t in db.Colleges
            //                 join d in db.DHCD_Nganhs on t.MaTruong equals d.MaTruong
            //                 where d.MaNganh.Trim() == MaNganh.Trim()
            //                 select t;
            //if(listtruong.Any())
            //{
            //    rptTruong.DataSource = listtruong;
            //    rptTruong.DataBind();
            //}
            var listkhoithi= from t in db.KhoiThis
                             select t;
            if (listkhoithi.Any())
            {
                drpKhoiThi.DataSource = listkhoithi;
                drpKhoiThi.DataTextField = "Khoi";
                drpKhoiThi.DataValueField = "Id";
                drpKhoiThi.DataBind();
            }
        }

        private PointAverage GetInfo(TextBox txt10, TextBox txt11, TextBox txt12, int testerId, SubjectName sbj)
        {
            //var average = new PointAverage
            //                  {
            //                      Ten = Commons.TryParseFloat(txt10.Text),
            //                      Eleven = Commons.TryParseFloat(txt11.Text),
            //                      Twelve = Commons.TryParseFloat(txt12.Text),
            //                      SubjectId = (int) sbj,
            //                      Block = string.Format("{0};{1};{2},{3};{4};{5}", "0", "0", "0", "0", "0", ""),
            //                      TesterId = testerId
            //                  };
            //return average;

            return null;

        }

        private float CalculateAverage(TextBox txt10, TextBox txt11, TextBox txt12)
        {
            float avg = (Commons.TryParseFloat(txt10.Text) + Commons.TryParseFloat(txt11.Text) +
                         Commons.TryParseFloat(txt12.Text)*2)/5;
            return avg;

        }

        private void GetTrungBinh()
        {
            var toan=GetInfo(txtToan10, txtToan11, txtToan12, 0, SubjectName.Toan);
            var ly=GetInfo(txtVatLy10, txtVatLy11, txtVatLy12, 0, SubjectName.Ly);
            var hoa=GetInfo(txtHoaHoc10, txtHoaHoc11, txtHoaHoc12, 0, SubjectName.Hoa);
            var van=GetInfo(txtVan10, txtVan11, txtVan12, 0, SubjectName.Van);
            var su=GetInfo(txtLichSu10, txtLichSu11, txtLichSu12, 0, SubjectName.Su);
            var dialy=GetInfo(txtDiaLy10, txtDiaLy11, txtDiaLy12, 0, SubjectName.Dia);
            var tienganh=GetInfo(txtTiengAnh10, txtTiengAnh11, txtTiengAnh12, 0, SubjectName.Anh);
            var sinh=GetInfo(txtSinh10, txtSinh11, txtSinh12, 0, SubjectName.Sinh);
        }

        public override void Dispose()
        {
            db.Dispose();
            base.Dispose();
            
        }
        private int LayDiemDaoDong()
        {
            if (radThree.Checked)
                return 3;
            if (radtwo.Checked)
                return 2;
            if (radone.Checked)
                return 1;
            return 0;
        }
        private string GetTruong(string khoithi,float diemtb)
        {

            string matruong = string.Empty;
            if(Session["maNganh"]!=null)
            {
                var MaNganh = Session["maNganh"] as string;
                var listtruong = from t in db.Colleges
                                 join d in db.DHCD_Nganhs on t.MaTruong equals d.MaTruong
                                 where d.MaNganh.Trim() == MaNganh.Trim() && d.KhoiThi.ToLower().Trim().Contains(khoithi.ToLower().Trim())
                                 select new {tentruong=t.TenTruong,matruong=t.MaTruong,khoi=d.KhoiThi,namthi=d.NamTuyenSinh};
                if(listtruong.Any())

                {

                    var max = diemtb + LayDiemDaoDong();
                    var min = diemtb - LayDiemDaoDong();
                    foreach (var item in listtruong)
                    {
                        string[] namtuyensinh = item.namthi.Split(';');
                        //Index 0: nam, 1: NV1, 2: NV2
                        if(namtuyensinh.Length>0)
                        {
                            foreach (var s in namtuyensinh)
                            {
                                if (Commons.TryParseFloat(s) <= max && Commons.TryParseFloat(s)>=min)
                                {
                                    if (string.IsNullOrEmpty(matruong))
                                        matruong = item.matruong;
                                    else
                                        matruong = matruong + ";" + item.matruong;
                                    break;
                                }
                            }
                           
                        }
                      
                    }
                }
            }
            
            return matruong;
        }

        protected void btnFinish_click(object sender, EventArgs e)
        {
            float k = Commons.TryParseFloat(txtDiemDuDoan.Text);
            var toan = CalculateAverage(txtToan10, txtToan11, txtToan12);
            var ly = CalculateAverage(txtVatLy10, txtVatLy11, txtVatLy12);
            var hoa = CalculateAverage(txtHoaHoc10, txtHoaHoc11, txtHoaHoc12);
            var van = CalculateAverage(txtVan10, txtVan11, txtVan12);
            var su = CalculateAverage(txtLichSu10, txtLichSu11, txtLichSu12);
            var dialy = CalculateAverage(txtDiaLy10, txtDiaLy11, txtDiaLy12);
            var tienganh = CalculateAverage(txtTiengAnh10, txtTiengAnh11, txtTiengAnh12);
            var sinh = CalculateAverage(txtSinh10, txtSinh11, txtSinh12);
            float tb = 0;
            tb = k;
            switch (Commons.TryParseInt(drpKhoiThi.SelectedValue))
            {
                case (int)khoiThi.A:
                    tb = (toan + ly + hoa)*k;
                    break;
                case (int)khoiThi.A1:
                    tb = (toan + ly + tienganh) * k;
                    break;
                case (int)khoiThi.B:
                    tb = (toan + sinh + hoa) * k;
                    break;
                case (int)khoiThi.C:
                    tb = (van + su+ dialy) * k;
                    break;
                case (int)khoiThi.D1:
                case (int)khoiThi.D2:
                case (int)khoiThi.D3:
                case (int)khoiThi.D4:
                case (int)khoiThi.D5:
                case (int)khoiThi.D6:
                     tb = (toan + van +  tienganh) * k;
                    break;
                case (int)khoiThi.H:
                case (int)khoiThi.N:
                case (int)khoiThi.M:
                case (int)khoiThi.T:
                case (int)khoiThi.V:
                case (int)khoiThi.S:
                case (int)khoiThi.R:
                case (int)khoiThi.K:
                    tb = k;
                    break;

            }

            Response.Redirect("/completed.aspx?ma=" + GetTruong(drpKhoiThi.Text.Trim(),tb));
        }
    }
}