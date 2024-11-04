using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;
using Candidate_DAOs;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        // Repo
        private readonly IJobPostingRepo jobPostingRepo;
        // ctor
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        // Get all Job Posting
        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }

        // Get Job Posting
        public JobPosting? GetJobPosting(string postingID) => jobPostingRepo.GetJobPosting(postingID);
        // Delete Job Posting By ID
        public bool deleteJobPosting(string postingID) => jobPostingRepo.deleteJobPosting(postingID);
        // Add new Job Posting
        public bool AddJobPosting(JobPosting jobPosting) => jobPostingRepo.AddJobPosting(jobPosting);
        // Update Job Posting
        public bool UpdateJobPosting(JobPosting jobPosting) => jobPostingRepo.UpdateJobPosting(jobPosting);
    }
}
