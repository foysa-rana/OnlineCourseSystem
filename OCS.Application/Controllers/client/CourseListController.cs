using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.client
{
    [Authorize(Roles = "User")]
    [AllowAnonymous]
    public class CourseListController : Controller
    {
        // GET: CourseList
        public ActionResult AllCourse()
        {
            return View();
        }
    }
}