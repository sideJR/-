using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace CM11_匯率查詢
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var url = "https://open.er-api.com/v6/latest/USD";
            var request = WebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";

            var response = request.GetResponse() as HttpWebResponse;
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
            var srcString = reader.ReadToEnd();

            var jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject<MyDta>(srcString);
            string TWD = jsonData.rates.TWD.ToString();
            Label1.Text = TWD;
            
            string JPY = jsonData.rates.JPY.ToString();
            Label2.Text = JPY;

            string GBP = jsonData.rates.GBP.ToString();
            Label3.Text = GBP;

            string KRW = jsonData.rates.KRW.ToString();
            Label4.Text = KRW;
        }
    }
}