using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    public class TrainerController : Controller
    {
        // Post: Trainer
        public ActionResult CreateTrainers()
        {
            return View();
        }

        // Get: Trainer
        public ActionResult TrainerList()
        {
            return View();
        }
    }
}