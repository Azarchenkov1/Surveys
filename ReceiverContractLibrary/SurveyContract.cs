using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.ReceiverContractLibrary
{
    public class SurveyContract
    {
        public string CreatorName { get; set; }
        public string SurveyName { get; set; }

        public string CreationDay { get; set; }
        public string CreationMonth { get; set; }
        public string CreationYear { get; set; }
    }
}
