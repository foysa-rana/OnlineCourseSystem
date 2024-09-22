using OCS.Core.ViewModel.SignUpViewModel;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OCS.Application.Controllers.client
{
    [Authorize(Roles = "User")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        UserSignUpService _service = new UserSignUpService();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trainer
        public ActionResult Trainer()
        {
            return View();
        }

        // POST: LogIn
        [HttpPost]
        public ActionResult LogIn(string route, string userName, string password)
        {
            var result = _service.GetAll().Where(x => x.UserName == userName && x.Password == password);
            if (result.Count() != 0)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        //GET: LogOut
        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Json(1);
        }
    }
}