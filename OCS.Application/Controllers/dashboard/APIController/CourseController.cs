using OCS.Core.ViewModel.CourseViewModel;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.dashboard.APIController
{
    public class CoursePatch
    {
        public int PurchaseCount { get; set; }
    }
    public class CourseController : ApiController
    {
        //service manager object
        CourseService _service;
        CourseController()
        {
            _service = new CourseService();
        }

        //SEARCH: api/Trainer/Search/query
        [Route("api/Course/Search/{query}")]
        [HttpGet]
        public IHttpActionResult Search(string query)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.Name.ToLower().Contains(query));
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
        }
        
        //CountVideo: api/Course/Videos
        [Route("api/Course/Videos/{id}")]
        [HttpGet]
        public IHttpActionResult Videos(int id)
        {
            try
            {
                var info = _service.CountVideo().Where(c => c.CourseId == id).Count();
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
        }

        // GET: api/Course
        public IHttpActionResult GetAll()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Course/GetAllOrderBy
        [Route("api/Course/GetAllOrderByDescending")]
        [HttpGet]
        public IHttpActionResult GetAllOrderByDescending()
        {
            try
            {
                var entities = _service.GetAll().OrderByDescending(e => e.PurchaseCount);
                return Ok(entities);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET: api/Course/GetAllOrderByRecent
        [Route("api/Course/GetAllOrderByDescendingRecent")]
        [HttpGet]
        public IHttpActionResult GetAllOrderByDescendingRecent()
        {
            try
            {
                var entities = _service.GetAll().OrderByDescending(e => e.Id);
                return Ok(entities);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Course/5
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

        // POST: api/Course
        public IHttpActionResult Post([FromBody] CourseView vm)
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

        // PUT: api/Course/5
        public IHttpActionResult Put(int id, [FromBody] CourseView vm)
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

        //PATCH: api/Course/Patch/id
        [Route("api/Course/Patch/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] CoursePatch vm)
        {
            try
            {
                var entity = _service.Get(id);
                int oldPurchaseCount = entity.PurchaseCount;
                int totalPurchaseCount = oldPurchaseCount + vm.PurchaseCount;
                var save = _service.Patch(id, totalPurchaseCount);
                return Ok(save);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
        }

        // DELETE: api/Course/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Remove(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
