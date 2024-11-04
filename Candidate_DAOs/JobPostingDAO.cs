using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
      
        private List<JobPosting> jobs;
        private static JobPostingDAO instance;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        // ctor
        public JobPostingDAO()
        {
         JobPosting jobPosting01 = new JobPosting("P0001", "System Administrator Specialist (MS Exchange, AD Voice)", "As our company is growing and we offer more service to our teams, we are looking for a Senior System engineer with a broad set of expertise in Messaging, voice systems, mail gateways, encryption (smime), etc.", new DateTime());

            JobPosting jobPosting02 = new JobPosting("P0002", "IT Security Manager", "Establish the Information Security Plan toward to updated ISO Framework as well as in alignment with IT Strategic Plan", new DateTime());


            JobPosting jobPosting03 = new JobPosting("P0003", "(Senior) IT Recruitment Consultant", "Developing and maintaining loyal business relationship with them aligning with our company and team business strategies", new DateTime());
          jobs =new List<JobPosting>();
            jobs.Add(jobPosting01);
            jobs.Add(jobPosting02);
            jobs.Add(jobPosting03);
        }
        // Get all Job Posting
        public List<JobPosting> GetJobPostings()
        {
            return jobs;
        }
        // Get Job Posting By ID
        public JobPosting? GetJobPosting(string postingID)
        {
            return jobs.FirstOrDefault(i =>i.PostingId.Equals(postingID));
        }
        // Delete Job Posting By ID
        public bool deleteJobPosting(string postingID)
        {
            bool result = false;
            JobPosting jobPosting = GetJobPosting(postingID);
            if (jobPosting != null)
            {
              jobs.Remove(jobPosting);
                result = true;
            }
            return result;
        }
        // Add new Job Posting
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            // check if already exist in DB
            JobPosting? jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 == null)
            {
                jobs.Add(jobPosting);
                
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }

        // Update Job Posting
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            // check if already exist in DB
            JobPosting? jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 != null)
            {
                // Auto update and save to DB
                jobPosting1.JobPostingTitle = jobPosting.JobPostingTitle;
                jobPosting1.Description = jobPosting.Description;
                jobPosting1.PostedDate = jobPosting.PostedDate;
                //dbContext.Entry<CandidateProfile>(candidateProfile).State 
                //    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }

    }

}
