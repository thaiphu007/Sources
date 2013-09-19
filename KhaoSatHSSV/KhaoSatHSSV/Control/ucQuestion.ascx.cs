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
                    if (ucChooseLevel != null)
                        totalPoint += ucChooseLevel.GetPoint;
                }
            }
            return totalPoint;
        }
    }
}