using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace MM1_毛毛購物網
{
    public partial class SiteMaster : MasterPage
    {
        SqlConnection sqlCon;   //連接資料庫
        SqlCommand sqlCom;
        String s;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected string FindMember(Label L, String User)
        {
            L.Text = "認證" + User + "中";

            sqlCom = sqlCon.CreateCommand();

            s = "SELECT * FROM [table] WHERE UserId = " + "'" + User + "'";
            sqlCom.CommandText = s; //使用SQL查詢語言

            try
            {
                sqlCom.ExecuteNonQuery();
                SqlDataReader sqlRed = sqlCom.ExecuteReader();

                //查詢資料庫資料是否存在
                if (sqlRed.Read() == true)
                {
                    string Pwd = Convert.ToString(sqlRed["UserPwd"]);
                    return Pwd;
                }
                else
                {
                    L.Text = "查無此人";
                    return null;
                }
            }
            catch(Exception)
            {
                Label4.Text = "資料庫失敗";
                return null;
            }
        }
        public SqlConnection OpenData(Label L)
        {
            //連接資料庫
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\many4\OneDrive\Desktop\程式集\文輝練習\ASP.NET\MM1_毛毛購物網\MM1_毛毛購物網\App_Data\Member.mdf;Integrated Security=True");

            if(sqlCon.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    sqlCon.Open();
                    L.Text = "連通成功";
                }
                catch(Exception)
                {
                    L.Text = "連通失敗";
                }
            }
            return sqlCon;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            OpenData(Label3);
            string CorrectPwd = FindMember(Label4, txtAccount.Text);
            
            sqlCon.Close();

            if(txtPassword.Text == CorrectPwd)           
                Session["User"] = "Paul";            
            else            
                txtPassword.Text = "密碼錯誤";
            
        }
    }
}