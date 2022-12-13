using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace CM6_台灣新冠疫情通報.Controllers
{
    public class HomeController : Controller
    {
        public string Report(string Notice)
        {            
            dynamic stuff = JObject.Parse(Notice);
            string Temp1 = stuff.ChineseName + "致死率高，請前線醫護人員小心。";
            string Temp2 = stuff.EnglishName + "is Terrible, please be careful!";
            string Temp3 = stuff.EnglishName + "est Terrible, s'il vous plaît soyez prudent!";
            
            return Temp1+Temp2+Temp3;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}