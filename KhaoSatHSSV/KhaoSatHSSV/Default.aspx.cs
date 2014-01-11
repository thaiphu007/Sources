using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
                ddlProvince.SelectedIndex = 0;
                ddlProvince_SelectedChanged(null,null);
                ddlDangHoc.SelectedIndex = 0;
                ddlDangHoc_SelectedChanged(null, null);
            }
        }

        protected void btn_check(object sender, EventArgs e)
        {
            //save tester
            if(!CheckValid()) return;
            int id;
            using (var db=new KHAOSATDataContext())
            {
                double point = 0;
                double.TryParse(string.IsNullOrEmpty(txtPointTest.Text.Trim()) ? "0" : txtPointTest.Text.Trim(),out point);
                var info = new Tester
                               {
                                   FullName = txtFullName.Text,
                                   Address = txtAddress.Text,
                                   Favorite = txtFavorite.Text,
                                   Gender = radNam.Checked,
                                   DateOfBirth = txtBirthDate.SelectedDate,
                                   WhereBirth = ddlWhereBirth.Text,
                                   Phone = txtPhone.Text,
                                   HightSchool = ddlTruong.Text,
                                   Province = ddlProvince.Text,
                                   Department = txtDepartment.Text,
                                   Reason = txtReason.Text,
                                   Scores = point,
                                   SchoolTest = ddlDuThi.Text,
                                   A = chkBlockA.Checked,
                                   B = chkBlockB.Checked,
                                   C=chkBlockC.Checked,
                                   D=chkBlockD.Checked,
                                   Orther = chkBlockOrther.Checked?txtBlockOrther.Text:string.Empty,
                                   SchoolLearning = ddlDangHoc.Text,
                                   IsMatch = radMatch.Checked,
                                   Reason1 = txtReason1.Text,
                                   MaNganh = ddlNganhHoc.SelectedValue
                               };
                db.Testers.InsertOnSubmit(info);
                db.SubmitChanges();
                Session["TesterId"] = info.Id;
                //save answer
                ucGroup1.SetPoint();
                //ucGroup2.SetPoint();
                //ucGroup3.SetPoint();
               // ucGroup4.SetPoint();
                //save average
                //int r=0;
                //int i=0;
                //int a=0;
                //int _e=0;
                //int c=0;
                //int s=0;
                //GetTotalGroupPoint(ref r,ref  i,ref a,ref _e,ref c,ref s);
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());
                db.PointAverages.InsertOnSubmit(GetInfo());


                info.ResultA = ucGroup1.GroupA;
                info.ResultR = ucGroup1.GroupR;
                info.ResultC = ucGroup1.GroupC;
                info.ResultI = ucGroup1.GroupI;
                info.ResultS = ucGroup1.GroupS;
                info.ResultE = ucGroup1.GroupE;
                db.SubmitChanges();
                id = info.Id;
            }

            Response.Redirect(string.Format("/ViewResult.aspx?id={0}",id));
            
        }

        private bool checkZero(int testerId)
        {
            var result = false;
            using (var db=new KHAOSATDataContext())
            {
                var total = (from s in db.Survey_Answers where s.TesterId == testerId select s).Sum(s => s.ChooseLevel);
                result = total == 0;
            }
            return result;
        }

        private void checkDefference(int index,GetList_AnswerResult item, ref List<GetList_AnswerResult> list)
        {
           
            bool IsRemove = false;
            for(int i=index;i<list.Count;i++)
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
                     list[i].MaNganh=item.MaNganh;
                IsRemove = false;
            }
        
        }

        /* Test Luat */
        private void UpdateTrainingExamples(List<GetList_AnswerResult> list)
        {
            var testID3=new ID3();
            for (int i = 1; i <= 54;i++)
            {
                testID3.attributes.Add(string.Format("Q{0}", i.ToString()));
                testID3.staticAtt.Add(string.Format("Q{0}", i.ToString()));
            }

            int index = 0;
            foreach (var item in list)
            {
                checkDefference(index, item, ref list);
                index++;
                if(item.TesterId != null && checkZero(item.TesterId.Value))
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
            var GetList_AnswerResult = new GetList_Answer_By_SinhVienResult
            {
                Q9 = 0,
                Q2 = 4,
                Q13 = 4,
                Q45 = 0,
                Q3 = 3
            };
            Response.Write(testID3.glDtID3Alg.GetNganh(GetList_AnswerResult));
       

        }

        private void LoadData()
        {
            using (var db = new KHAOSATDataContext())
            {
                ddlProvince.DataSource = db.Provinces;
                ddlProvince.DataTextField = "ProvinceName";
                ddlProvince.DataValueField= "Code";
                ddlProvince.DataBind();

                ddlWhereBirth.DataSource = db.Provinces;
                ddlWhereBirth.DataTextField = "ProvinceName";
                ddlWhereBirth.DataValueField = "Code";
                ddlWhereBirth.DataBind();

                ddlDuThi.DataSource = db.Colleges;
                ddlDuThi.DataTextField = "TenTruong";
                ddlDuThi.DataValueField = "MaTruong";
                ddlDuThi.DataBind();

                ddlDangHoc.DataSource = db.Colleges;
                ddlDangHoc.DataTextField = "TenTruong";
                ddlDangHoc.DataValueField = "MaTruong";
                ddlDangHoc.DataBind();

                ddlNganhHoc.DataSource = db.Nganhs;
                ddlNganhHoc.DataTextField = "TenNganh";
                ddlNganhHoc.DataValueField = "Ma";
                ddlNganhHoc.DataBind();

                //List<GetList_AnswerResult> list = db.GetList_Answer().ToList();
           //     list = list.Where(t => t.TesterId == 238 || t.TesterId == 520).ToList();
                //UpdateTrainingExamples(list);
            }
        }

        private PointAverage GetInfo(TextBox txt10,TextBox txt11,TextBox txt12,int testerId,SubjectName sbj)
        {
            var average = new PointAverage
            {
                Ten =Commons.TryParseFloat(txt10.Text),
                Eleven = Commons.TryParseFloat(txt11.Text),
                Twelve = Commons.TryParseFloat(txt12.Text),
                SubjectId = (int)sbj,
                Block = string.Format("{0};{1};{2},{3};{4};{5}", "0", "0", "0", "0", "0", ""),
                TesterId = testerId
            };
            return average;
        }

        private PointAverage GetInfo()
        {
            var average = new PointAverage
            {
                Ten = 0,
                Eleven = 0,
                Twelve = 0,
                SubjectId = null,
                Block =
                    string.Format("{0};{1};{2},{3};{4};{5}",  "0","0",  "0","0",  "0",""),
                TesterId = null
            };
            return average;
        }

        private void GetTotalGroupPoint(ref int r,ref  int i, ref int a,ref  int e,ref  int c, ref int s)
        {
            r = ucGroup1.GroupR;// +ucGroup2.GroupR + ucGroup3.GroupR + ucGroup4.GroupR;
            i = ucGroup1.GroupI;// +ucGroup2.GroupI + ucGroup3.GroupI + ucGroup4.GroupI;
            a = ucGroup1.GroupA;// +ucGroup2.GroupA + ucGroup3.GroupA + ucGroup4.GroupA;
            e = ucGroup1.GroupE;// +ucGroup2.GroupE + ucGroup3.GroupE + ucGroup4.GroupE;
            c = ucGroup1.GroupC;// +ucGroup2.GroupC + ucGroup3.GroupC + ucGroup4.GroupC;
            s = ucGroup1.GroupS;// +ucGroup2.GroupS + ucGroup3.GroupS + ucGroup4.GroupS;
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                ShowMessage("Nhập Họ tên");
                return false;
            }
            
            return true;
        }

        private void ShowMessage(string message)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), string.Format("message_{0}", DateTime.Now.Ticks.ToString()), string.Format("<script type='text/javascript'> $(document).ready(function(){{alert('{0}');showSurvey('survey5')}});</script>", message));
        }

        protected void ddlProvince_SelectedChanged(object sender, EventArgs e)
        {
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.TruongTHPTs where t.MaTinh == Commons.TryParseInt(ddlProvince.SelectedValue) select t);
                ddlTruong.DataSource = list;
                ddlTruong.DataTextField = "TenTruong";
                ddlTruong.DataValueField = "MaTruong";
                ddlTruong.DataBind();
            }
        }

        protected void ddlDangHoc_SelectedChanged(object sender, EventArgs e)
        {
            using (var db = new KHAOSATDataContext())
            {
                var list =
                    (from t in db.Nganhs join dn in db.DHCD_Nganhs on t.Ma equals dn.MaNganh 
                     where dn.MaTruong==ddlDangHoc.SelectedValue select t);
                ddlNganhHoc.DataSource = list;
                ddlNganhHoc.DataTextField = "TenNganh";
                ddlNganhHoc.DataValueField = "Ma";
                ddlNganhHoc.DataBind();
            }
        }
    }
}