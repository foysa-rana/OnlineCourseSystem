using Microsoft.Reporting.WebForms;
using OCS.Service.Manager.Report;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.Application.Controllers.dashboard
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        //report service obj
        TrainerReportService _trainerReport = new TrainerReportService();

        // GET: Reports
        public ActionResult TrainerReport()
        {
            return View();
        }

        //Get All Trainer
        [HttpPost]
        [Route("Reports/GetAllTrainer")]
        public JsonResult GetAllTrainer()
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Reports"), "AllTrainer.rdlc");
                viewer.LocalReport.ReportPath = path;

                var generalInfo = _trainerReport.GetAllTrainer();
                var gi = new ReportDataSource("AllTrainerDataSet", generalInfo);
                viewer.LocalReport.DataSources.Add(gi);



                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Report";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Report/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Get Individual Trainer
        [HttpPost]
        [Route("Reports/GetIndividualTrainer/{query}")]
        public JsonResult GetIndividualTrainer(int query)
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Reports"), "IndividualTrainer.rdlc");
                viewer.LocalReport.ReportPath = path;

                var generalInfo = _trainerReport.GetIndividualTrainer(query);
                var gi = new ReportDataSource("IndividualTrainerDataSet", generalInfo);
                viewer.LocalReport.DataSources.Add(gi);



                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Report";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Report/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Reports
        public ActionResult TraineeReport()
        {
            return View();
        }
    }
}