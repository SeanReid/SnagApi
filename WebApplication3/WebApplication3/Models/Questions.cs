using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Questions
    {
        public Questions()
        {
            JobApplicationAnswers = new HashSet<JobApplicationAnswers>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public ICollection<JobApplicationAnswers> JobApplicationAnswers { get; set; }
    }
}
