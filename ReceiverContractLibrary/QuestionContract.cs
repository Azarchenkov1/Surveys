using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.ReceiverContractLibrary
{
    public class QuestionContract
    {
        public string SurveyId { get; set; }
        public string QuestionDescription { get; set; }
        public string AdditionalInformation { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
    }
}
