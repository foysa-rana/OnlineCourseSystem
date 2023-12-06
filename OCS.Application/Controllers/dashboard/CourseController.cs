using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult CreateCourse()
        {
            return View();
        }

        // GET: Course
        public ActionResult CourseList()
        {
            return View();
        }
    }
}