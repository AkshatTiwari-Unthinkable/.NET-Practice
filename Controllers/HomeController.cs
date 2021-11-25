using System;
using System.IO;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Name=null,string Phone=null,string Salary=null)
        {
            TempData["name"] = Name;
            TempData["phone"] = Phone;
            TempData["salary"] = Salary;
            return View();
        }

        public ActionResult AddEmployee ()
        {
            ViewBag.Name = TempData["name"];
            ViewBag.Phone = TempData["phone"];
            ViewBag.Salary = TempData["salary"];
            var path = @"C:\TxtFile\emp1.txt";
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("");
                sw.Write(ViewBag.Name.ToString());
                sw.Write("\t");
                sw.Write(ViewBag.Phone);
                sw.Write("\t");
                sw.Write(ViewBag.Salary);
            }

            return View();
        }

        public ActionResult ShowEmployee()
        {
            ViewBag.path= @"C:\TxtFile\emp1.txt";

            return View();
        }

        public ActionResult DeleteEmployee(string Empname="None")
        {
            var path = @"C:\TxtFile\emp1.txt";
            TempData["flag"] = false;

            string tempFile = Path.GetTempFileName();
          
            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains(Empname) )
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        TempData["flag"] = true;
                    }
                  
                }
            }
            System.IO.File.Delete(path);
            System.IO.File.Move(tempFile, path);
            return View();
        }

        public ActionResult AfterDelete()
        {
            ViewBag.flag = TempData["flag"];
            return View();
        }
    }
}