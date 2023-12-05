using OCS.Core.ViewModel.Trainer;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.dashboard.APIController
{
    public class TrainerController : ApiController
    {
        //sevice manager object
        TrainerService _service;
        TrainerController()
        {
            _service = new TrainerService();
        }

        // GET: api/Trainer
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);
                return Ok(entity);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Trainer/5
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

        // POST: api/Trainer
        public IHttpActionResult Post([FromBody] TrainerView vm)
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

        // PUT: api/Trainer/5
        public IHttpActionResult Put(int id, [FromBody] TrainerView vm)
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

        // DELETE: api/Trainer/5
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
