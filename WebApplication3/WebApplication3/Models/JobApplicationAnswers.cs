using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebApplication3.Models
{
    public partial class JobApplicationAnswers
    {
        private int m_QuestionId = 0;
        public int AnswerId { get; set; }
        public int JobApplicationId { get; set; }
        public int QuestionId {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    return Int32.Parse(Id.Remove(0, 2));
                }
                else
                {
                    return m_QuestionId;
                }
            }

            set
            {
                m_QuestionId = value;
            }
        }
        public string Answer { get; set; }
        public string Id { get; set; }

        public JobApplications JobApplication { get; set; }
        public Questions Question { get; set; }

        public int RemoveText(string input)
        {
            return Int32.Parse(input.Remove(0, 2));
        }
    }
}
