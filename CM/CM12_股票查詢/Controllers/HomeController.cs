using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CM12_股票查詢.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetData()
        {
            string WebAddress = "https://stockinfo.com.tw";
            string Query = "?stock=2089&time=1008&turnover=0813";
            string Result = WebAddress + Query;
            var Q = HttpUtility.ParseQueryString(Query);

            TempData["StockId"] = Q["stock"].ToString();
            TempData["Time"] = Q["time"].ToString();
            TempData["Turnover"] = Q["turnover"].ToString();
            TempData["Message"] = Result;

            string Response = "Acer#Apple,Benz#BMW";
            string[] MyArray = Response.Split('#', ',');

            TempData["Test"] = MyArray[1];

            return RedirectToAction("Index", "Home");
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