using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace MS2_毛毛購物網
{
    public partial class Checkout : System.Web.UI.Page
    {
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        string s;
        static DataTable dataTable;
        static string LoginId = "mary";
        static int MoneySum = 0, OrderCount = 0;
        
        //連接資料庫
        protected void OpenData(Label L)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\many4\OneDrive\Desktop\程式集\文輝練習\.NET\MM1_毛毛購物網\MS2_毛毛購物網\App_Data\Member.mdf;Integrated Security=True");
            
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
        }
        //顯示訂單資訊
        protected void ShowOrder()
        {
            OpenData(Label1);

            s = "SELECT Cart.OrderId, Cart.ItemId, Item.ItemName, Item.ItemPrice FROM Cart INNER JOIN Item ON Cart.ItemId=Item.ItemId WHERE (UserId='" + LoginId + "')";
            Label2.Text = s;
            sqlCom = new SqlCommand(s, sqlCon);
            sqlCom.ExecuteNonQuery();
            
            dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCom);
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            OrderCount = GridView1.Rows.Count;
            Label3.Text = "共" + OrderCount + "項商品";

            for(int i=0;i<OrderCount;i++)
            {
                MoneySum += Convert.ToInt16(GridView1.Rows[i].Cells[3].Text);
                //ToInt16最多100萬，ToInt32最大值1000億
            }
            Label3.Text += " 合計" + MoneySum + "元";

            int usermoney = GetMoney();
            Label4.Text = "存款餘額" + usermoney + "元";


            sqlCon.Close();
        }
        //User餘額
        protected int GetMoney()
        {
            int z = 0;
            OpenData(Label1);

            s = "SELECT * FROM Bank WHERE (UserId='" + LoginId + "')";
            Label2.Text = s;

            try
            {
                sqlCom = new SqlCommand(s, sqlCon);
                sqlCom.ExecuteNonQuery();
                SqlDataReader dataReader = sqlCom.ExecuteReader();

                while(dataReader.Read() == true)
                {
                    z = Convert.ToInt16(dataReader["Money"]);
                }
            }
            catch (Exception)
            {
                Label1.Text = "SQL失敗";
            }
            return z;
        }
        //修改User餘額
        protected void MinusMoney(int y)
        {
            int z = GetMoney();
            z -= y;

            OpenData(Label1);

            try
            {
                s = "UPDATE Bank SET Money=" + z + " WHERE (UserId='" + LoginId + "')";
                Label2.Text = s;

                sqlCom = new SqlCommand(s, sqlCon);
                sqlCom.ExecuteNonQuery();

                Label4.Text = "存款餘額" + z + "元";
            }
            catch (Exception)
            {
                Label1.Text = "修改失敗";
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            MinusMoney(MoneySum);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowOrder();
            }
        }
    }
}