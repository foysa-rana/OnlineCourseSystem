using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(HttpPostedFileBase photo)
        {
            var path = Server.MapPath("~/images/Course-img");
            var fileName = Path.GetFileName(photo.FileName);
            var fullPath = Path.Combine(path, fileName);
            photo.SaveAs(fullPath);
            return Json(fileName);
        }

        // GET: Course
        public ActionResult CourseList()
        {
            return View();
        }
    }
}