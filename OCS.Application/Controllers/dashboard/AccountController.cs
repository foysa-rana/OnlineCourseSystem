using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
    }
}