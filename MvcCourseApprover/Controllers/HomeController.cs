using MvcCourseApprover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCourseApprover.Controllers
{
    public class HomeController : Controller
    {
        //ORIENTDBEntities
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Apply()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Apply(STUDENT stud)
        {
            using (var db = new DBGR93Entities())
            {
                var newstudent = db.STUDENTs.Create();

                newstudent.NAME = stud.NAME;
                newstudent.SURNAME = stud.SURNAME;
                newstudent.MOBILE = stud.MOBILE;
                newstudent.EMAIL = stud.EMAIL;

                db.STUDENTs.Add(newstudent);

                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Approve(int id)
        {
            var db = new DBGR93Entities();
            var student = db.STUDENTs.FirstOrDefault(a => a.ID == id);
            if (student != null)
            {
                student.APPROVED = true;
            }
            db.SaveChanges();
            return RedirectToAction("Appeals");
        }

        public ActionResult Appeals()
        {
            DBGR93Entities   db = new DBGR93Entities();
            var USER = db.STUDENTs.Where(a => a.APPROVED == false || a.APPROVED == null).ToList();
            db.Dispose();
            return View(USER);
        }
    }
}