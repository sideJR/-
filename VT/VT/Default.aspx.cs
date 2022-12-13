using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Web.Configuration;

namespace VT
{
    public partial class _Default : Page
    {
        SqlConnection LinkOne;
        SqlCommand LinkCom;
        SqlDataReader Reader;
        string LinkText;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //第一次載入
            {
                Session["LoginId"] = null;
                TestPanel.Visible = true;
            }
            
            if(Session["LoginId"] == null)
            {
                VotePanel.Visible = false;
            }
            else
            {
                VotePanel.Visible = true;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            OpenLinkOne(ConnectLabel);

            string InputName = AccountTextBox.Text;
            string CorrectPwd = FindUser(TestLabel, InputName);

            if(CorrectPwd == null)
            {
                MessageLabel.Text = "不好意思，找不到您的帳號";
                VotePanel.Visible = false;
            }
            else if(PasswordTextBox.Text == CorrectPwd)
            {
                MessageLabel.Text = "恭喜您，已經登入成功";
                UserPanel.Visible = true;
                VotePanel.Visible = true;

                Session["LoginId"] = AccountTextBox.Text;
                string InputId = AccountTextBox.Text;
                UserIdLabel.Text = "住戶ID：" + InputId;

                int weight = GetUserWeight(TestLabel, InputId);
                UserWeightLabel.Text = "權重：" + weight.ToString();
            }
            else
            {
                MessageLabel.Text = "不好意思，您密碼輸入錯誤";
                VotePanel.Visible = false;
            }

            LinkOne.Close();
        }
        //連線
        protected void OpenLinkOne(Label L)
        {
            LinkOne = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectOne"].ConnectionString.ToString());

            if(LinkOne.State == System.Data.ConnectionState.Closed) 
            {
                try
                {
                    LinkOne.Open();
                    L.Text = "連線成功";
                }
                catch(Exception)
                {
                    L.Text = "連線失敗";
                }
            }
        }
        //驗證使用者
        protected string FindUser(Label L, String User)
        {
            OpenLinkOne(L);
            LinkCom = LinkOne.CreateCommand();
            LinkText = "SELECT * FROM Voter WHERE UserId =" + "'" + User + "'";
            L.Text = LinkText;
            
            LinkCom.CommandText = LinkText;
            try
            {
                LinkCom.ExecuteNonQuery();
                Reader = LinkCom.ExecuteReader();

                if(Reader.Read() == true)
                {
                    string Pwd = Convert.ToString(Reader["UserPwd"]);
                    return Pwd;
                }
                else
                {
                    L.Text = "無此住戶";
                    return null;
                }
            }
            catch (Exception)
            {
                L.Text = "讀取資料庫失敗";
                return null;
            }
        }
        //獲取權重
        protected int GetUserWeight(Label L, String InputId)
        {
            OpenLinkOne(L);
            LinkCom = LinkOne.CreateCommand();
            LinkText = "SELECT UserWeight FROM Voter WHERE UserId='" + InputId + "'";            
            L.Text = LinkText;

            LinkCom.CommandText = LinkText;
            try
            {
                LinkCom.ExecuteNonQuery();
                Reader = LinkCom.ExecuteReader();

                if(Reader.Read() == true)
                {
                    int Weight = Convert.ToInt32(Reader["UserWeight"]);
                    LinkOne.Close();
                    
                    return Weight;
                }
                else
                {
                    TestLabel.Text = "抓不到用戶的 Weight";
                    LinkOne.Close();

                    return 0;
                }
            }
            catch (Exception)
            {
                TestLabel.Text = "讀取資料庫失敗";
                LinkOne.Close();

                return 0;
            }
        }
        //Update Vote
        protected void StoreUserVote(Label L, String User, String Choice)
        {
            OpenLinkOne(ConnectLabel);
            LinkCom = LinkOne.CreateCommand();
            LinkText = "UPDATE Voter SET Vote='" + Choice + "' WHERE UserId='" + User + "'";
            L.Text = LinkText;

            LinkCom.CommandText = LinkText;
            try
            {
                LinkCom.ExecuteNonQuery();
                TestLabel.Text = "投票資料儲存成功";
            }
            catch (Exception)
            {
                TestLabel.Text = "投票資料儲存失敗";
                MessageLabel.Text = "不好意思!並未收到您的投票!";
            }

            LinkOne.Close();
        }

        protected void VoteControlButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "請您投下同意、反對或棄權票!";

            //改變 VoteControlButton 外觀
            VoteControlButton.BackColor = System.Drawing.Color.LightGray;
            VoteControlButton.BorderColor = System.Drawing.Color.Yellow;

            if(VoteControlButton.Text == "我要投票")
            {
                VoteControlPanel.Visible = true;
                VoteControlButton.Text = "隱藏投票區";
                MessageLabel.Text = "已為您隱藏投票區";

                VoteControlButton.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                VoteControlPanel.Visible = false;
                VoteControlButton.Text = "我要投票";
            }
        }

        protected void YesButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "您投了同意票!";
            
            string VoteChoice = "yes";
            string PersonId = Session["LoginId"].ToString();
            StoreUserVote(TestLabel, PersonId, VoteChoice);
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "您投了反對票!";

            string VoteChoice = "no";
            string PersonId = Session["LoginId"].ToString();
            StoreUserVote(TestLabel, PersonId, VoteChoice);
        }

        protected void DropButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "您投了棄權票!";

            string VoteChoice = "drop";
            string PersonId = Session["LoginId"].ToString();
            StoreUserVote(TestLabel, PersonId, VoteChoice);
        }
    }
}