using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Surveys.DAL;
using Surveys.Library;
using Surveys.ReceiverContractLibrary;
using Surveys.SenderContractLibrary;

namespace Surveys.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> question([FromBody]QuestionContract question)
        {
            Logger.HttpRequestOutput("POST", "api/question/question");
            int questionid = DataBaseService.SaveQuestion(question);
            bool result = DataBaseService.SaveAnswer(question, questionid);
            return Json(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> questions(int id)
        {
            Logger.HttpRequestOutput("GET", "api/question/questions");
            List<SenderQuestionContract> QuestionList = DataBaseService.GetQuestionList(id);
            return Json(QuestionList);
        }
    }
}