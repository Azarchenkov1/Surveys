using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surveys.Library;
using Surveys.Model;
using Surveys.ReceiverContractLibrary;
using Surveys.SenderContractLibrary;

namespace Surveys.DAL
{
    public static class DataBaseService
    {
        static Model.Model model = Model.Model.ModelFactory();

        public static List<Survey> GetSurveyList()
        {
            var Query = (from query_survey in model.SurveyList
                         select new
                         {
                             query_survey.Id,
                             query_survey.SurveyName,
                             query_survey.CreatorName,
                             query_survey.CreationDay,
                             query_survey.CreationMonth,
                             query_survey.CreationYear
                         }).ToList();

            List<Survey> SurveyList = new List<Survey>();

            Query.ForEach(i => {
                Survey survey = new Survey();

                survey.Id = i.Id;
                survey.SurveyName = i.SurveyName;
                survey.CreatorName = i.CreatorName;
                survey.CreationDay = i.CreationDay;
                survey.CreationMonth = i.CreationMonth;
                survey.CreationYear = i.CreationYear;

                SurveyList.Add(survey);
            });

            return SurveyList;
        }

        public static bool SaveSurvey(SurveyContract surveyContract)
        {
            try {
                Survey survey = new Survey()
                {
                    CreatorName = surveyContract.CreatorName,
                    CreationDay = Int32.Parse(surveyContract.CreationDay),
                    CreationMonth = Int32.Parse(surveyContract.CreationMonth),
                    CreationYear = Int32.Parse(surveyContract.CreationYear),
                    SurveyName = surveyContract.SurveyName
                };
                model.SurveyList.Add(survey);
                model.SaveChanges();

                return true;

            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return false;
            }
        }

        public static bool SaveSurvey(int id, SurveyContract surveyContract)
        {
            try {
                var survey = (from query_survey in model.SurveyList
                              where query_survey.Id == id
                              select query_survey).FirstOrDefault();

                survey.CreatorName = surveyContract.CreatorName;
                survey.CreationDay = Int32.Parse(surveyContract.CreationDay);
                survey.CreationMonth = Int32.Parse(surveyContract.CreationMonth);
                survey.CreationYear = Int32.Parse(surveyContract.CreationYear);
                survey.SurveyName = surveyContract.SurveyName;

                model.SaveChanges();

                return true;

            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return false;
            }
        }

        public static Survey GetSurvey(int id)
        {
            try {
                var Query = (from query_survey in model.SurveyList
                             where query_survey.Id == id
                             select new
                             {
                                 query_survey.Id,
                                 query_survey.SurveyName,
                                 query_survey.CreatorName,
                                 query_survey.CreationDay,
                                 query_survey.CreationMonth,
                                 query_survey.CreationYear
                             }).ToList();

                Survey survey = new Survey();

                Query.ForEach(i => {

                    survey.Id = i.Id;
                    survey.SurveyName = i.SurveyName;
                    survey.CreatorName = i.CreatorName;
                    survey.CreationDay = i.CreationDay;
                    survey.CreationMonth = i.CreationMonth;
                    survey.CreationYear = i.CreationYear;
                });

                return survey;

            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return null;
            }
        }

        public static bool Delete(int id)
        {
            try { 
                var survey = (from query_survey in model.SurveyList
                              where query_survey.Id == id
                              select query_survey).FirstOrDefault();

                model.Remove(survey);
                model.SaveChanges();
                return true;
            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return false;
            }
        }

        public static int SaveQuestion(QuestionContract questionContract)
        {
            try
            {
                Question question = new Question()
                {
                    SurveyId = Int32.Parse(questionContract.SurveyId),
                    QuestionDescription = questionContract.QuestionDescription,
                    AdditionalInformation = questionContract.AdditionalInformation,
                };

                model.QuestionList.Add(question);
                model.SaveChanges();
                return question.Id;
            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return 0;
            }
        }

        public static bool SaveAnswer(QuestionContract questionContract, int id)
        {
            try
            {
                SaveAnswer(questionContract.Answer1, id);
                SaveAnswer(questionContract.Answer2, id);
                SaveAnswer(questionContract.Answer3, id);
                return true;
            }
            catch (Exception ex)
            {
                Logger.ExceptionOutput(ex);
                return false;
            }
        }

        public static bool SaveAnswer(string str, int id)
        {
            try
            {
                Answer answer = new Answer()
                {
                    QuestionId = id,
                    AnswerDescription = str
                };

                model.AnswerList.Add(answer);
                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.ExceptionOutput(ex);
                return false;
            }
        }

        public static List<SenderQuestionContract> GetQuestionList(int id)
        {
            try
            {
                var Query = (from query_question in model.QuestionList
                             where query_question.SurveyId == id
                             select query_question).ToList();

                List<SenderQuestionContract> QuestionList = new List<SenderQuestionContract>();

                foreach (Question question in Query)
                {
                    SenderQuestionContract Question = new SenderQuestionContract()
                    {
                        Id = question.Id,
                        questionDescription = question.QuestionDescription,
                        additionalInformation = question.AdditionalInformation,
                        answerList = GetAnswerList(question.Id)
                    };

                    QuestionList.Add(Question);
                }
                return QuestionList;
            } catch (Exception ex) {
                Logger.ExceptionOutput(ex);
                return null;
            }
        }

        public static SenderQuestionContract GetQuestion(int id)
        {
            try
            {
                var Query = (from query_question in model.QuestionList
                             where query_question.Id == id
                             select query_question).Single();

                SenderQuestionContract Question = new SenderQuestionContract()
                {
                    Id = Query.Id,
                    questionDescription = Query.QuestionDescription,
                    additionalInformation = Query.AdditionalInformation,
                    answerList = GetAnswerList(Query.Id)
                };

                return Question;
            } catch (Exception ex) {
                Logger.ExceptionMethod("GetQuestion(int id)");
                Logger.ExceptionOutput(ex);
                return null;
            }
        }

        static List<SenderAnswerContract> GetAnswerList(int id)
        {
            try
            {
                var AnswerQuery = (from query_answer in model.AnswerList
                                   where query_answer.QuestionId == id
                                   select query_answer).ToList();

                List<SenderAnswerContract> AnswerList = new List<SenderAnswerContract>();

                AnswerQuery.ForEach(i =>
                {
                    SenderAnswerContract sac = new SenderAnswerContract();
                    sac.Id = i.Id;
                    sac.answerDescription = i.AnswerDescription;
                    AnswerList.Add(sac);
                });

                return AnswerList;
            } catch (Exception ex) {
                Logger.ExceptionMethod("GetAnswerList(int id)");
                Logger.ExceptionOutput(ex);
                return null;
            }
        }
    }
}
