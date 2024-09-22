using OCS.Core.PatchModel;
using OCS.Core.ViewModel.SignUpViewModel;
using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.client.APIController
{
    public class UserModel
    {
        public string UserName { get; set; }
    }
    public class UserController : ApiController
    {
        //service manager object
        UserSignUpService _service;
        CourseService _courseService;
        UserController()
        {
            _service = new UserSignUpService();
            _courseService = new CourseService();
        }

        //GET: api/UserNameValidation
        [Route("api/UserNameValidation")]
        [HttpPost]
        public IHttpActionResult UserNameValidation([FromBody] UserModel User)
        {
            try
            {
                var exist = _service.GetAll().Where(m => m.UserName == User.UserName);
                if (exist.Count() > 0)
                {
                    return Json("exist");
                }
                else
                {
                    return Json("not exist");
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        //GET: api/User/Specific/id
        [Route("api/User/Specific/{id}")]
        [HttpGet]
        // GET: api/User/5
        public IHttpActionResult Specific(int id)
        {
            try
            {
                var entity = _service.Get(id);
                string courseId = entity.CourseId;
                string[] courseIdArr = courseId.Split(',');
                string[,] courseArr = new string[courseIdArr.Count(), courseIdArr.Count()];
                int count = 0;
                foreach(string course in courseIdArr)
                {
                    int courseInt = Convert.ToInt32(course);
                    var courseEntity = _courseService.Get(courseInt);
                    string courseName = courseEntity.Name;
                    string entityId = courseEntity.Id.ToString();
                    courseArr[0, count] = entityId;
                    courseArr[1, count] = courseName;
                    count++;
                }
                return Json(courseArr);
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
                var exist = _service.GetAll().Where(m => m.UserName == vm.UserName);
                if(exist.Count() == 0)
                {
                    var entity = _service.Post(vm);
                    return Ok(entity);
                }
                else
                {
                    return Json("exist");
                }
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

        // PATCH: api/User/Patch/id
        [Route("api/User/Patch/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] UserCoursePatch vm)
        {
            try
            {
                var oldData = _service.Get(id);
                string oldCourseId = oldData.CourseId;
                string allCourseId;
                if (oldCourseId == null)
                {
                    allCourseId = vm.CourseId;
                }
                else
                {
                    string[] oldCourseIdArr = oldCourseId.Split(',');
                    foreach(string item in oldCourseIdArr)
                    {
                        if(item == vm.CourseId)
                        {
                            string[] arr = {"exist", vm.CourseId };
                            return Json(arr);
                        }
                    }
                    allCourseId = oldCourseId + "," + vm.CourseId;
                }
                var entity = _service.Patch(id, allCourseId);
                return Json(vm.CourseId);
            }
            catch (Exception)
            {
                return Json(0);
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
