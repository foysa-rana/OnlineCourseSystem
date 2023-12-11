using OCS.Core.ViewModel.SignUp;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.client.APIController
{
    public class UserController : ApiController
    {
        //service manager object
        UserSignUpService _service;
        UserController()
        {
            _service = new UserSignUpService();
        }
        // GET: api/User
        public IHttpActionResult GetAll()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody] UserSignUpView vm)
        {
            try
            {
                var entity = _service.Post(vm);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody] UserSignUpView vm)
        {
            try
            {
                var entity = _service.Put(id, vm);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
