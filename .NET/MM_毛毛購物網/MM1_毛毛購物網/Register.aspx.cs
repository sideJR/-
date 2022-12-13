using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MM1_毛毛購物網
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Panel Px = this.Master.FindControl("Panel1") as Panel;
            
            //登入區項目消失
            Px.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            SiteMaster siteMaster = (SiteMaster)this.Master;
            Label Lx = this.Master.FindControl("Label3") as Label;
            
            SqlConnection sqlCon = siteMaster.OpenData(Lx);
            SqlCommand sqlCom = sqlCon.CreateCommand();

            //SQL新增
            String s = "INSERT INTO [table] (UserId, UserPwd) VALUES('" + txtAccount2.Text + "','" + txtPassword2.Text + "')";
            
            Label L4 = this.Master.FindControl("Label4") as Label;
            L4.Text = s;

            sqlCom.CommandText = s;
            try
            {
                sqlCom.ExecuteNonQuery();
                L4.Text = "新增成功";
            }
            catch(Exception)
            {
                L4.Text = "新增失敗";
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}