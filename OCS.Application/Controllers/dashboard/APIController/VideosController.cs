using OCS.Core.ViewModel.VideosViewModel;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.dashboard.APIController
{
    public class VideosController : ApiController
    {
        //service manager object
        VideosService _service = new VideosService();

        // GET: api/Videos
        [Route("api/AllVideos/{id}")]
        [HttpGet]
        public IHttpActionResult AllVideos(int id)
        {
            try
            {
                var entities = _service.GetAll().Where(c => c.CourseId == id);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Videos/5
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

        // POST: api/Videos
        public IHttpActionResult Post([FromBody]VideosView vm)
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

        // PUT: api/Videos/5
        public IHttpActionResult Put(int id, [FromBody]VideosView vm)
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

        // DELETE: api/Videos/5
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
