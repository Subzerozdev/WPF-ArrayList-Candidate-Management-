using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;
using Candidate_DAOs;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        // Get all Job Posting
        public List<JobPosting> GetJobPostings()
            =>JobPostingDAO.Instance.GetJobPostings();
        // Get Job Posting
        public JobPosting? GetJobPosting(string postingID) => JobPostingDAO.Instance.GetJobPosting(postingID);
        // Delete Job Posting By ID
        public bool deleteJobPosting(string postingID) => JobPostingDAO.Instance.deleteJobPosting(postingID);
        // Add new Job Posting
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);
        // Update Job Posting
        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
    }


}
