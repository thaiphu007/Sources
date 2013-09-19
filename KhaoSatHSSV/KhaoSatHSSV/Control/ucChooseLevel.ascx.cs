using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KhaoSatHSSV.Control
{
    public partial class ucChooseLevel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int QuestionId { get; set; }
        public int GetPoint
        {
            get
            {
                if (radMuc1.Checked)
                    return 0;
                if (radMuc2.Checked)
                    return 1;
                if (radMuc3.Checked)
                    return 2;
                if (radMuc4.Checked)
                    return 3;
                if (radMuc5.Checked)
                    return 4;
                return 0;

            }
        }
    }
}