using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClient.MCU;

namespace MyClient
{
    public partial class _Default : Page
    {
        McuMathSoap Practice;
        protected void Page_Load(object sender, EventArgs e)
        {
            Practice = new McuMathSoapClient();
            Label2.Text = Practice.HelloWorld();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int d1 = Convert.ToInt16(TextBox1.Text);
            int d2 = Convert.ToInt16(TextBox3.Text);

            string c = TextBox2.Text;
            int x = 0;
            switch (c)
            {
                case "+":
                    x = Practice.Add(d1, d2);
                    break;
                case "-":
                    x = Practice.Minus(d1, d2);
                    break;
                case "*":
                    x = Practice.Cross(d1, d2);
                    break;
                case "/":
                    x = Practice.Divide(d1, d2);
                    break;
                default:
                    x = 0;
                    break;
            }
            Label1.Text = x.ToString();
        }

    }
}