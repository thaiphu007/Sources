using System;
using System.Linq;
using System.Web.UI.WebControls;
using KhaoSatHSSV.Classes;
using KhaoSatHSSV.Classes.DB;

namespace KhaoSatHSSV
{
    public partial class SelectDepartment : System.Web.UI.Page
    {

        public string[] temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request.QueryString["gr"]))
                {
                    string[] groups = Request.QueryString["gr"].Split(';');
                    temp = Request.QueryString["gr"].Split(';');
                    if(groups.Length==2)
                    {

                        groups[0] = Commons.TenNhom(Commons.TryParseInt(groups[0]));
                        groups[1] = Commons.TenNhom(Commons.TryParseInt(groups[1]));
                        rptNhom.DataSource = groups;
                        rptNhom.DataBind();
                        //using (var db=new KHAOSATDataContext())
                        //{
                        //    var list = (from n in db.Groups_Nganhs join g in db.Nganhs on n.Manganh.Trim() equals g.Ma.Trim()
                        //                where 
                        //                    (n.NhomId == Commons.TryParseInt(groups[0]) ||
                        //                     n.NhomId == Commons.TryParseInt(groups[1])) 
                        //                select g).Distinct();
                        //    ddlNganh.DataSource = list;
                        //    ddlNganh.DataTextField = "TenNganh";
                        //    ddlNganh.DataValueField= "Ma";
                        //    ddlNganh.SelectedIndex = 0;
                        //    ddlNganh_SelectedIndex(null,null);
                        //    UpdatePanel5.Update();
                        //}
                    }
                }
            }
        }

                protected void rptNhom_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var rpt = e.Item.FindControl("rptNganh") as Repeater;
                if(rpt!=null)
                {
                    int nhomId;
                    string ma = Commons.TenNhom(Commons.TryParseInt(temp[0]));
                    if (ma == e.Item.DataItem.ToString())
                        nhomId = Commons.TryParseInt(temp[0]);
                    else
                        nhomId = Commons.TryParseInt(temp[1]);
                    using (var db = new KHAOSATDataContext())
                    {
                        var list = (from n in db.Groups_Nganhs
                                    join g in db.Nganhs on n.Manganh.Trim() equals g.Ma.Trim()
                                    where
                                        (n.NhomId == nhomId)
                                    select g.TenNganh).Distinct();
                        rpt.DataSource = list;
                        rpt.DataBind();
                    }
                }
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("/tuvanchonnganh.aspx");
        }
    }
}