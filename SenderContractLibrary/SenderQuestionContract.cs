using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.SenderContractLibrary
{
    public class SenderQuestionContract
    {
        public int Id { get; set; }
        public string questionDescription { get; set; }
        public string additionalInformation { get; set; }

        public List<SenderAnswerContract> answerList = new List<SenderAnswerContract>();
    }
}
