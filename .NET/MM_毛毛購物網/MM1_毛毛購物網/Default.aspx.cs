using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MM1_毛毛購物網
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if(Session["User"] != null)
            {
                Panel2.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            //ContentPage 傳資料給 MasterPage
            Label Lx = this.Master.FindControl("Label3") as Label;
            Lx.Text = "買的越多，折扣越多";
        }
    }
}