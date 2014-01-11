using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class Results : System.Web.UI.Page
    {
        public string Groups
        {
            get { return ViewState["Groups"] == null ? string.Empty : ViewState["Groups"].ToString(); }
            set { ViewState["Groups"]=value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                using (var db = new KHAOSATDataContext())
                {
                    var info =
                        (from s in db.SinhViens where s.Id == long.Parse(Request.QueryString["id"]) select s).
                            FirstOrDefault();
                   

                    var listgroup =
                        (from su in db.Summary_ResultGroup(long.Parse(Request.QueryString["id"]), 1)
                         select su).ToList();
                    if (info != null)
                    {

                        liFullName.Text = info.HoTen;
                        liR.Text = info.ResultR.ToString();
                        liI.Text = info.ResultI.ToString();
                        liE.Text = info.ResultE.ToString();
                        liS.Text = info.ResultS.ToString();
                        liC.Text = info.ResultC.ToString();
                        liA.Text = info.ResultA.ToString();

                        if (listgroup.Any())
                        {
                            int validResult = 0;
                            string groups = string.Empty;
                            foreach (var groupResult in listgroup)
                            {
                                if (string.IsNullOrEmpty(groups))
                                    groups = groupResult.GroupId.ToString();
                                else
                                    groups +=   ";"+groupResult.GroupId.ToString();
                                if (groupResult.GroupId == (int) GroupName.A)
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm A: {0} điểm", groupResult.Total));
                                else if (groupResult.GroupId == (int) GroupName.R)
                                {
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm R: {0} điểm", groupResult.Total));
                                    validResult++;
                                }
                                else if (groupResult.GroupId == (int) GroupName.C)
                                {
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm C: {0} điểm", groupResult.Total));
                                    validResult++;
                                }
                                else if (groupResult.GroupId == (int) GroupName.E)
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm E: {0} điểm", groupResult.Total));
                                else if (groupResult.GroupId == (int) GroupName.I)
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm I: {0} điểm", groupResult.Total));
                                else if (groupResult.GroupId == (int) GroupName.S)
                                    BindData(string.IsNullOrEmpty(liNhom1.Text) ? liNhom1 : liNhom2,
                                             string.Format("Nhóm S: {0} điểm", groupResult.Total));

                            }
                            if (validResult == 2)
                            {
                                liMessage.Text = "Kết quả của bạn không phù hợp. Bạn vui lòng thực hiện lại khảo sát";
                                btnContinue.Visible = false;
                                btnPrevious.Visible = true;
                            }
                            else
                            {
                                int count = 0;
                                Groups = groups;
                                foreach (var group in groups.Split(';'))
                                {
                                    if (!string.IsNullOrEmpty(group) && info.KhaNang.Contains(group))
                                        count++;
                                }
                                if (count < 2)
                                {
                                    btnPrevious.Visible = true;
                                    liMessage.Text =
                                        "Kết quả của bạn không phù hợp khả năng ban đầu bạn chọn. Bạn chấp nhận kết quả này không?. Nếu có Chọn \"Tiếp Tục\".";
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }

    }
         
     private void BindData(Literal liNHom,string strResult)
     {
         liNHom.Text = strResult;
     }

    protected void btn_Continue(object sender, EventArgs e)
    {
        
        Response.Redirect(string.Format("/selectdepartment.aspx?gr={0}", Groups));
    }

        protected void btn_Previous(object sender, EventArgs e)
        {
            using (var db=new KHAOSATDataContext())
            {
                db.KhaoSat_SinhViens.DeleteAllOnSubmit(db.KhaoSat_SinhViens.Where(k => k.SinhVienId == long.Parse(Request.QueryString["id"])));
            }
            Response.Redirect(string.Format("/survey.aspx"));    
        }
    }
}