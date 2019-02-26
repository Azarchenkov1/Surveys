﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Surveys.DAL;
using Surveys.Library;
using Surveys.Model;
using Surveys.ReceiverContractLibrary;

namespace Surveys.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> surveys()
        {
            Logger.HttpRequestOutput("GET", "api/survey/surveys");
            List<Survey> SurveyList = DataBaseService.GetSurveyList();
            return Json(SurveyList);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> survey([FromBody]SurveyContract survey)
        {
            Logger.HttpRequestOutput("POST", "api/survey/survey");
            bool result = DataBaseService.SaveSurvey(survey);
            if(result) { return Json("true"); }
            else { return Json("false"); }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> survey(int id)
        {
            Logger.HttpRequestOutput("GET", "api/survey/survey");
            Survey survey = DataBaseService.GetSurvey(id);
            if (survey != null) { return Json(survey); }
            else { return Json("false"); }
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> survey(int id, [FromBody]SurveyContract survey)
        {
            Logger.HttpRequestOutput("PUT", "api/survey/survey");
            bool result = DataBaseService.SaveSurvey(id, survey);
            if(result) { return Json("true"); }
            else { return Json("false"); }
        }
    }
}