﻿using System;
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

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> question(int id)
        {
            Logger.HttpRequestOutput("GET", "api/question/question");
            SenderQuestionContract Question = DataBaseService.GetQuestion(id);
            return Json(Question);
        }

        [HttpDelete("question/{id}")]
        public async Task<IActionResult> deletequestion(int id)
        {
            Logger.HttpRequestOutput("DELETE", "api/question/question");
            bool result = DataBaseService.DeleteQuestion(id);
            return Json(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> questions()
        {
            Logger.HttpRequestOutput("GET", "api/question/questions");
            List<SenderQuestionContract> QuestionList = DataBaseService.GetQuestionList();
            return Json(QuestionList);
        }

        [HttpDelete("surveyquestions/{id}")]
        public async Task<IActionResult> deletequestionlist(int id)
        {
            Logger.HttpRequestOutput("DELETE", "api/question/surveyquestions");
            bool result = DataBaseService.DeleteQuestionList(id);
            return Json(result);
        }

        [HttpPost("[action]/{questionid}/{surveyid}")]
        public async Task<IActionResult> survey(int questionid, int surveyid)
        {
            Logger.HttpRequestOutput("POST", "api/question/survey");
            bool result = DataBaseService.Subscribe(questionid, surveyid);
            return Json(result);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> question(int id,[FromBody] QuestionContract question)
        {
            Logger.HttpRequestOutput("PUT", "api/question/question");
            bool result = DataBaseService.EditQuestion(id, question);
            return Json(result);
        }
    }
}