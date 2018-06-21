using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly WebAppContext _context;

        public JobApplicationsController(WebAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<JobApplications> GetAcceptedJobApplications()
        {
            var allQuestions = _context.Questions;
            return _context.JobApplications.Where(j => 
                j.JobApplicationAnswers.All(jaa => 
                    allQuestions.FirstOrDefault(q => q.QuestionId == jaa.QuestionId).Answer == jaa.Answer))
                .ToList();
        }

        // POST: api/JobApplications
        [HttpPost]
        public string PostJobApplications([FromBody] JobApplications jobApplication)
        {
            var allQuestions = _context.Questions.ToList();
            bool AcceptOrReject = jobApplication.Questions.All(jaa =>
                    allQuestions.FirstOrDefault(q => q.QuestionId == jaa.QuestionId)?.Answer == jaa.Answer);

            _context.JobApplications.Add(jobApplication);
            _context.SaveChangesAsync();

            return AcceptOrReject ? "Accept" : "Reject";
        }
    }
}