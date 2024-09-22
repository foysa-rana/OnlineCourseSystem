using OCS.Service.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    [Authorize(Roles = "Admin")]
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVideo(HttpPostedFileBase video, string videoName, string courseName, int id)
        {
            string DateTime = System.DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
            if (id == 0)
            {
                var path = Server.MapPath(string.Format("~/Content Media/Videos/" + courseName));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = DateTime + " " + videoName;
                var extension = Path.GetExtension(video.FileName).ToLower();
                var fullName = fileName + extension;
                var fullPath = Path.Combine(path, fullName);
                video.SaveAs(fullPath);
                return Json(fullName);
            }
            else
            {
                if(video != null)
                {
                    VideosService _service = new VideosService();
                    var entity = _service.Get(id);
                    var existFile = entity.Video;
                    string sourceFolder = entity.Course.Name;
                    string existFilePath = Request.MapPath("~/Content Media/Videos/" + sourceFolder + "/" + existFile);
                    if (System.IO.File.Exists(existFilePath))
                    {
                        System.IO.File.Delete(existFilePath);
                    }
                    var path = Server.MapPath(string.Format("~/Content Media/Videos/" + courseName));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = DateTime + " " + videoName;
                    var extension = Path.GetExtension(video.FileName).ToLower();
                    var fullName = fileName + extension;
                    var fullPath = Path.Combine(path, fullName);
                    video.SaveAs(fullPath);
                    return Json(fullName);
                }
                else
                {
                    VideosService _service = new VideosService();
                    var entity = _service.Get(id);
                    string sourceVideo = entity.Video;
                    string sourceFolder = entity.Course.Name;
                    var path = Server.MapPath(string.Format("~/Content Media/Videos/" + courseName));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = DateTime + " " + videoName;
                    string source = Server.MapPath(string.Format("~/Content Media/Videos/" + sourceFolder + "/" + sourceVideo));
                    string destination = Path.Combine(path, fileName);


                    System.IO.File.Move(source, destination);
                    return Json(fileName);
                }
            }
            
        }

        //course list
        public ActionResult Courses()
        {
            return View();
        }

        //video list
        public ActionResult VideoList()
        {
            return View();
        }
    }
}