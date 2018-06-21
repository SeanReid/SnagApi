using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class JobApplications
    {
        public JobApplications()
        {
            JobApplicationAnswers = new HashSet<JobApplicationAnswers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobApplicationAnswers> JobApplicationAnswers { get; set; }
        public ICollection<JobApplicationAnswers> Questions { get { return JobApplicationAnswers; } }
    }
}
