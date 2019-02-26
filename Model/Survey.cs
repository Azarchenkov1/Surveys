using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Model
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        public string CreatorName { get; set; }
        public string SurveyName { get; set; }

        public int CreationDay { get; set; }
        public int CreationMonth { get; set; }
        public int CreationYear { get; set; }

        public ICollection<Question> QuestionList { get; set; }
    }
}
