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
    }
}
