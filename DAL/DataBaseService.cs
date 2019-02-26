using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Surveys.Model;
using Surveys.ReceiverContractLibrary;

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
                             query_survey.SurveyId,
                             query_survey.SurveyName,
                             query_survey.CreatorName,
                             query_survey.CreationDay,
                             query_survey.CreationMonth,
                             query_survey.CreationYear
                         }).ToList();

            List<Survey> SurveyList = new List<Survey>();

            Query.ForEach(i => {
                Survey survey = new Survey();

                survey.SurveyId = i.SurveyId;
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
        }

        public static bool SaveSurvey(int id, SurveyContract surveyContract)
        {
            if (id <= model.SurveyList.Count())
            {
                var survey = (from query_survey in model.SurveyList
                             where query_survey.SurveyId == id
                             select query_survey).FirstOrDefault();

                survey.CreatorName = surveyContract.CreatorName;
                survey.CreationDay = Int32.Parse(surveyContract.CreationDay);
                survey.CreationMonth = Int32.Parse(surveyContract.CreationMonth);
                survey.CreationYear = Int32.Parse(surveyContract.CreationYear);
                survey.SurveyName = surveyContract.SurveyName;

                model.SaveChanges();

                return true;
            } else {
                return false;
            }
        }

        public static Survey GetSurvey(int id)
        {
            if (id <= model.SurveyList.Count())
            {
                var Query = (from query_survey in model.SurveyList
                             where query_survey.SurveyId == id
                             select new
                             {
                                 query_survey.SurveyId,
                                 query_survey.SurveyName,
                                 query_survey.CreatorName,
                                 query_survey.CreationDay,
                                 query_survey.CreationMonth,
                                 query_survey.CreationYear
                             }).ToList();

                Survey survey = new Survey();

                Query.ForEach(i => {

                    survey.SurveyId = i.SurveyId;
                    survey.SurveyName = i.SurveyName;
                    survey.CreatorName = i.CreatorName;
                    survey.CreationDay = i.CreationDay;
                    survey.CreationMonth = i.CreationMonth;
                    survey.CreationYear = i.CreationYear;
                });

                return survey;
            } else {
                return null;
            }
        }

        public static bool Delete(int id)
        {
            if (id <= model.SurveyList.Count())
            {
                var survey = (from query_survey in model.SurveyList
                              where query_survey.SurveyId == id
                              select query_survey).FirstOrDefault();

                model.Remove(survey);
                model.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
