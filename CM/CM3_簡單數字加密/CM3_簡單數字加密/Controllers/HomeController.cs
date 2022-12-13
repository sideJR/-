using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CM3_簡單數字加密.Controllers
{
    public class HomeController : Controller
    {
        public string Hello(string name, string secret)
        {
            int OldNumber = Convert.ToInt16(name);
            int key = Convert.ToInt16(secret);
            int NewNumber = OldNumber + key;
            String Result = Convert.ToString(NewNumber);
            
            return Result;
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