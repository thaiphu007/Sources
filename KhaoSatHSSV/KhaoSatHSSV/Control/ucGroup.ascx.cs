using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV.Control
{
    public partial class ucGroup : System.Web.UI.UserControl
    {
        private readonly KHAOSATDataContext db=new KHAOSATDataContext();

        public int QuestionType { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (db.Groups != null)
                {
                    Session["list"] = db.Groups.ToList();
                    rptGroup.DataSource = Session["list"] as List<Group>;
                    rptGroup.DataBind();
                }
            }
        }

        public int GroupR { get; set; }
        public int GroupI { get; set; }
        public int GroupA { get; set; }
        public int GroupS { get; set; }
        public int GroupE { get; set; }
        public int GroupC { get; set; }

        protected void rptGroup_ItemDatabound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Group;
            var ctrlQuestion = e.Item.FindControl("GroupQuestion") as ucQuestion;
            if (item != null && ctrlQuestion != null)
                ctrlQuestion.DataSourceQuestion = item.Questions.Where(q => q.QuestionType == QuestionType);
        }
        public void SetPoint()
        {
            
            foreach (RepeaterItem item in rptGroup.Items)
            {
                if (item != null)
                {
                    var groupId = item.FindControl("hdGroupId") as HiddenField;
                    var question = item.FindControl("GroupQuestion") as ucQuestion;
                    if (question != null && groupId!=null)
                    {
                        switch (int.Parse(groupId.Value))
                        {
                            case (int)GroupName.R:
                                GroupR = question.GetTotalPoint();
                                break;
                            case (int)GroupName.I:
                                GroupI = question.GetTotalPoint();
                                break;
                            case (int)GroupName.A:
                                GroupA = question.GetTotalPoint();
                                break;
                            case (int)GroupName.S:
                                GroupS = question.GetTotalPoint();
                                break;
                            case (int)GroupName.E:
                                GroupE = question.GetTotalPoint();
                                break;
                            case (int)GroupName.C:
                                GroupC = question.GetTotalPoint();
                                break;
                        }
                        
                    }
                }
            }
            
        }
        public override void Dispose()
        {
            base.Dispose();
            db.Dispose();
        }
    }
}