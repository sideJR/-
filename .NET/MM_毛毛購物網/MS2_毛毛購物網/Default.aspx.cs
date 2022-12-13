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
    public partial class _Default : Page
    {
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        String s;
        static DataTable dataTable;
        static String SelItemId, SelItemName, SelItemPic, SelItemPlace;
        static int SelItemPrice;
        static String LoginId = "paul";
        static int OrderId = 1;

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Detail")
            {
                int k = Convert.ToInt16(e.CommandArgument);
                SelItemId = GridView1.Rows[k].Cells[0].Text;

                OpenData(Label1);
                sqlCom = sqlCon.CreateCommand();
                s = "SELECT * FROM Item WHERE ItemId='" + SelItemId + "'";
                sqlCom.CommandText = s;

                try
                {
                    sqlCom.ExecuteNonQuery();
                    Label2.Text = "搜索成功";
                    SqlDataReader dataReader = sqlCom.ExecuteReader();
                    while (dataReader.Read() == true)
                    {
                        SelItemName = Convert.ToString(dataReader["ItemName"]);
                        SelItemPrice = Convert.ToInt16(dataReader["ItemPrice"]);
                        SelItemPic = Convert.ToString(dataReader["ItemPic"]);
                        SelItemPlace = Convert.ToString(dataReader["ItemPlace"]);

                        Label3.Text = SelItemName;
                        Label4.Text = SelItemPrice.ToString();
                        Label5.Text = SelItemPlace;
                        Image1.ImageUrl = "/Images/" + SelItemPic + ".jpg";
                    }
                }
                catch(Exception)
                {
                    Label2.Text = "搜索失敗";
                }

                sqlCon.Close();
            }
        }
        protected void ShowItem()
        {
            OpenData(Label1);

            s = "SELECT * FROM ITEM WHERE (1=1)";
            Label2.Text = s;

            sqlCom = new SqlCommand(s, sqlCon);
            sqlCom.ExecuteNonQuery();

            dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCom);
            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            sqlCon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OpenData(Label1);

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");    //取得時間
            sqlCom = sqlCon.CreateCommand();
            s = "INSERT INTO Cart (OrderId, UserId, ItemId, ItemPrice, ItemPlace, OrderTime) VALUES(" + OrderId + ",'" + LoginId + "','" + SelItemId + "'," + SelItemPrice + ",N'" + SelItemPlace + "','" + time + "')";
            OrderId += 1;
            Label2.Text = s;
            sqlCom.CommandText = s;

            try
            {
                sqlCom.ExecuteNonQuery();
                Label2.Text += "加入購物車成功";
            }
            catch (Exception)
            {
                Label2.Text = "加入購物車失敗";
            }
            sqlCon.Close();
        }

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowItem();
            }
        }
    }
}