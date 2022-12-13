using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM9_旁聽名單.Models;

namespace CM9_旁聽名單.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Student student1 = new Student(3, "陳大方", "男", "應中");
            Student student2 = new Student(4, "李神仙", "男", "資管");
            Student student3 = new Student(5, "劉銘傳", "男", "應中");
            Student student4 = new Student(6, "孫美美", "女", "資管");
            Student student5 = new Student(7, "小菜", "女", "資管");


            LinkedList<Student> MyStudents = new LinkedList<Student>();
            MyStudents.AddLast(student1);
            MyStudents.AddLast(student2);
            MyStudents.AddLast(student3);
            MyStudents.AddLast(student4);
            MyStudents.AddLast(student5);

            return View(MyStudents);
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