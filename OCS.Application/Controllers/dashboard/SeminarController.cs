using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    [Authorize(Roles = "Admin")]
    public class SeminarController : Controller
    {
        // GET: Seminar
        public ActionResult CreateSeminar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSeminar(HttpPostedFileBase photo)
        {
            var path = Server.MapPath("~/images/Seminar-img");
            var fileName = Path.GetFileName(photo.FileName);
            var fullPath = Path.Combine(path, fileName);
            photo.SaveAs(fullPath);
            return Json(fileName);
        }

        // GET: Seminar
        public ActionResult SeminarList()
        {
            return View();
        }
    }
}