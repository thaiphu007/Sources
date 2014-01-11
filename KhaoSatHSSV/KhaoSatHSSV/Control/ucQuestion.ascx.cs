using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV.Control
{
    public partial class ucQuestion : System.Web.UI.UserControl
    {
        public int GroupId { get; set; }
        private readonly KHAOSATDataContext db=new KHAOSATDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (DataSourceQuestion!=null){
                    rptQuestion.DataSource = DataSourceQuestion.ToList();
                    rptQuestion.DataBind();
                }

            }
        }

        public IEnumerable<Question> DataSourceQuestion { get; set; }

        public int GetTotalPoint()
        {
            int totalPoint = 0;
          
            foreach (RepeaterItem item in rptQuestion.Items)
            {
                if(item!=null)
                {
                    var ucChooseLevel = item.FindControl("ucChooseLevel1") as ucChooseLevel;
                    var hdQuestionId = item.FindControl("hdQuestionId") as HiddenField;
                    if (ucChooseLevel != null&&hdQuestionId!=null)
                    {
                        int point = ucChooseLevel.GetPoint;
                        if (Session["TesterId"] != null)
                        {
                            var answer = new Survey_Answer
                                             {
                                                 ChooseLevel = point,
                                                 QuestionId = int.Parse(hdQuestionId.Value)

                                             };
                          
                            if (Session["TesterId"] != null)
                                answer.TesterId = int.Parse(Session["TesterId"].ToString());
                            db.Survey_Answers.InsertOnSubmit(answer);
                        }
                       
                        if (Session["SVID"] != null)
                        {
                            var sv = new KhaoSat_SinhVien()
                            {
                                ChooseLevel = point,
                                QuestionId = int.Parse(hdQuestionId.Value),
                                SinhVienId = (long)Session["SVID"],
                                SoLan =1
                            };
                           db.KhaoSat_SinhViens.InsertOnSubmit(sv);
                        }
                        db.SubmitChanges();
                      totalPoint += point;
                    }
                }
            }
            return totalPoint;
        }
    }
}