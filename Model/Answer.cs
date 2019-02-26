using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surveys.Model
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerDescription { get; set; }
    }
}
