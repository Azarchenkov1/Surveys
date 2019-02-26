using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Surveys.DAL;
using Surveys.Library;
using Surveys.Model;

namespace Surveys.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> surveys()
        {
            Logger.HttpRequestOutput("GET", "api/Survey/Main");
            List<Survey> SurveyList = DataBaseService.GetSurveyList();
            return Json(SurveyList);
        }
    }
}