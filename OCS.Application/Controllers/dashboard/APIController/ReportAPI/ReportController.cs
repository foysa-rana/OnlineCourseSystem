using OCS.Service.Manager.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OCS.Application.Controllers.dashboard.APIController.ReportAPI
{
    public class ReportController : ApiController
    {
        //sevice manager object
        TrainerReportService _trainerService;
        ReportController()
        {
            _trainerService = new TrainerReportService();
        }

        //GETALL: Reports/AllTrainer
        [Route("Reports/AllTrainer")]
        [HttpGet]
        public IHttpActionResult AllTrainer()
        {
            try
            {
                var info = _trainerService.GetAllTrainer();
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
        }

        //GET: Reports/IndividualTrainer/query
        [Route("Reports/IndividualTrainer/{query}")]
        [HttpGet]
        public IHttpActionResult IndividualTrainer(int query)
        {
            try
            {
                var info = _trainerService.GetIndividualTrainer(query);
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest("Match not found");
            }
        }
    }
}
