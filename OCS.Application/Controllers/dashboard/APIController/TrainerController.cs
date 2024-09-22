using OCS.Core.ViewModel.TrainerViewModel;
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

        //SEARCH: api/Trainer/Search/query
        [Route("api/Trainer/Search/{query}")]
        [HttpGet]
        public IHttpActionResult Search(string query)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.FName.ToLower().Contains(query) ||
                    c.LName.ToLower().Contains(query) ||
                    c.Position.ToLower().Contains(query) ||
                    c.TrainerId.ToLower().Contains(query));
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
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
