using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace OCS.Application.Controllers.dashboard.APIController
{
    public class LogInModel
    {
        public string User { get; set; }
        public string PasswordSignIn { get; set; }
        public bool Remember { get; set; }
    }
    public class AuthenticationController : ApiController
    {
        UserSignUpService _service = new UserSignUpService();

        // POST: api/Authentication/LogIn
        [Route("api/Authentication/LogIn")]
        [HttpPost]
        public IHttpActionResult LogIn([FromBody]LogInModel vm)
        {
            try
            {
                var result = _service.GetAll().Where(x => x.UserName == vm.User && x.Password == vm.PasswordSignIn);
                if (result.Count() != 0)
                {
                    string id;
                    foreach (var user in result)
                    {
                        if(user.UserRole == "Admin")
                        {
                            id = user.Id.ToString();
                            if (vm.Remember == true)
                            {
                                FormsAuthentication.SetAuthCookie(id, true);
                            }
                            else
                            {
                                FormsAuthentication.SetAuthCookie(id, false);
                            }
                            return Json(1);
                        }
                        else
                        {
                            return Json(0);
                        }

                    }
                    return Json(vm);

                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Authentication/LogOut
        [Route("api/Authentication/LogOut")]
        [HttpGet]
        public IHttpActionResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return Json(1);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
