using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;  //載入DataTable函數庫

namespace MS2_毛毛購物網
{
    public partial class About : Page
    {
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        string s;
        string SelectItemId;
        static DataTable dataTable;

        protected void ShowItem()
        {
            OpenData(Label1);
            s = "SELECT * FROM Item WHERE (1=1)";
            Label2.Text = s;
            sqlCom = new SqlCommand(s, sqlCon);
            sqlCom.ExecuteNonQuery();

            dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCom);

            adapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();   //將結果連結到GridView
            BindPic();

            sqlCon.Close();
        }
        protected void BindPic()
        { 
            for(int i=0;i<GridView1.Rows.Count;i++)
            {
                Image img = (Image)GridView1.Rows[i].FindControl("Px");
                img.ImageUrl = "/Images/" + dataTable.Rows[i][3].ToString() + ".jpg";
            }
        }
        protected void OpenData(Label L)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\many4\OneDrive\Desktop\程式集\文輝練習\.NET\MM1_毛毛購物網\MS2_毛毛購物網\App_Data\Member.mdf;Integrated Security=True");
            if (sqlCon.State == System.Data.ConnectionState.Closed)
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Del")
            {
                int k = Convert.ToInt16(e.CommandArgument);
                SelectItemId = GridView1.Rows[k].Cells[0].Text;

                OpenData(Label1);

                sqlCom = sqlCon.CreateCommand();
                s = "DELETE Item WHERE ItemId='" + SelectItemId + "'";

                Label2.Text = s;
                sqlCom.CommandText = s;

                try
                {
                    sqlCom.ExecuteNonQuery();
                    Label2.Text = "刪除成功";
                    ShowItem();
                }
                catch(Exception)
                {
                    Label2.Text = "刪除失敗";
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            OpenData(Label1);
            sqlCom = sqlCon.CreateCommand();
            s = "INSERT INTO Item (ItemId, ItemName, ItemPrice, ItemPlace, ItemPic) VALUES('" + txtId.Text + "',N'" + txtName.Text + "',"
                + Convert.ToInt16(txtPrice.Text) + ",N'" + txtPlace.Text + "','" + txtImg.Text + "')";
            Label2.Text = s;

            sqlCom.CommandText = s;
            try
            {
                sqlCom.ExecuteNonQuery();
                Label2.Text += "新增成功";
                ShowItem();
            }
            catch (Exception)
            {
                Label2.Text = "新增失敗";
            }
            sqlCon.Close();
        }
        
        protected void btnUploadImg_Click(object sender, EventArgs e)
        {
            var PicName = FileUpload1.PostedFile.FileName;  //上傳圖片檔名稱
            String PicFullName = Server.MapPath("~/Images/") + PicName;
            try
            {
                FileUpload1.SaveAs(PicFullName);
                Label2.Text = "上傳成功";
            }
            catch(Exception)
            {
                Label2.Text = "上傳失敗";
            }
        }
    }
}