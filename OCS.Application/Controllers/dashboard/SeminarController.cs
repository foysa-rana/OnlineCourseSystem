using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    public class SeminarController : Controller
    {
        // GET: Seminar
        public ActionResult CreateSeminar()
        {
            return View();
        }

        // GET: Seminar
        public ActionResult SeminarList()
        {
            return View();
        }
    }
}