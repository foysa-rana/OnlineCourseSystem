using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    [Authorize(Roles = "Admin")]
    public class TrainerController : Controller
    {
        // Post: Trainer
        public ActionResult CreateTrainers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrainers(HttpPostedFileBase photo)
        {
            var path = Server.MapPath("~/images/TrainerProfile-img");
            var fileName = Path.GetFileName(photo.FileName);
            var fullPath = Path.Combine(path, fileName);
            photo.SaveAs(fullPath);
            return Json(fileName);
        }

        // Get: Trainer
        public ActionResult TrainerList()
        {
            return View();
        }
    }
}