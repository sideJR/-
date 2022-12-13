using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CM7_銘傳數學家
{
    /// <summary>
    ///McuMath 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class McuMath : System.Web.Services.WebService
    {        
        string T = "";
        public McuMath()
        {
            T = "銘傳數學大師";
        }
        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }[WebMethod]
        public int Minus(int a, int b)
        {
            return a - b;
        }
        [WebMethod]
        public int Cross(int a, int b) 
        {
            return a * b;
        }[WebMethod]
        public int Divide(int a, int b)
        {
            return a / b;
        }        
        [WebMethod]
        public string HelloWorld()
        {
            return T;
        }
    }
}
