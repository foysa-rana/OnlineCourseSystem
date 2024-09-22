using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.client
{
    [Authorize(Roles = "User")]
    [AllowAnonymous]
    public class CourseViewController : Controller
    {
        UserSignUpService _service = new UserSignUpService();

        // GET: CourseView
        public ActionResult Course(string id)
        {
            try
            {
                var userId = Convert.ToInt16(User.Identity.Name);
                var entity = _service.Get(userId).CourseId;
                if (entity != null)
                {
                    string[] CourseId = entity.Split(',');
                    foreach (string course in CourseId)
                    {
                        if (course == id)
                        {
                            ViewBag.available = "exist";
                        }
                    }
                }
            }
            catch(Exception)
            {

            }
            
            return View();
        }
        // GET: CourseView
        public ActionResult Video()
        {
            return View();
        }
    }
}