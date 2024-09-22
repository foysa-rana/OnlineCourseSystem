using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.client
{
    [Authorize(Roles = "User")]
    [AllowAnonymous]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Checkout()
        {
            return View();
        }
    }
}