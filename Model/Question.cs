using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Model
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string AdditionalInformation { get; set; }

        public ICollection<Answer> AnswerList { get; set; }
    }
}
