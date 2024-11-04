using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Candidate_BusinessObjects;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private List<JobPosting> _jobs;
        private string _filepath = "D:\\C#_Practice_PE\\PRN221_TrialTest\\PRN221PE_FA22_TrialTest_NguyenThanhNam - Copy\\CandidateManagement_NguyenThanhNam\\File\\JobPosting.xml";
        private static JobPostingDAO instance;
        public JobPostingDAO()
        {
            _jobs = ReadJobs();
        }
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
        // Read all JobPosting by xml
        public List<JobPosting> ReadJobs()
        {
            XDocument xdoc = XDocument.Load(_filepath);
            return (from job in xdoc.Descendants("JobPosting")
                    select new JobPosting
                    {
                        PostingId = job.Element("PostingId")?.Value ?? string.Empty,
                        JobPostingTitle = job.Element("JobPostingTitle")?.Value ?? string.Empty,
                        PostedDate = DateTime.TryParse(job.Element("PostedDate")?.Value, out var birthday) ? birthday : default(DateTime),
                        Description = job.Element("Description")?.Value ?? string.Empty,
                    }).ToList();
        }
        // Save to xml file
        private void save()
        {
            // Serialize the list to XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<JobPosting>), new XmlRootAttribute("JobPostings"));
            using (TextWriter writer = new StreamWriter(_filepath))
            {
                serializer.Serialize(writer, _jobs);
            }
        }
        // Get all Job Posting
        public List<JobPosting> GetJobPostings()
        {
            //return dbContext.JobPostings.ToList();
            return _jobs;
        }
        // Get Job Posting By ID
        public JobPosting? GetJobPosting(string postingID)
        {
            return _jobs.FirstOrDefault(j => j.PostingId.Equals(postingID));
        }
        // Delete Job Posting By ID
        public bool deleteJobPosting(string postingID)
        {
            bool result = false;
            JobPosting? jobPosting = GetJobPosting(postingID);
            if (jobPosting != null)
            {
                _jobs.Remove(jobPosting);
                save();
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
                _jobs.Add(jobPosting);
                save();
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
            JobPosting? jobPosting1 = _jobs.FirstOrDefault(j => j.PostingId.Equals(jobPosting.PostingId));
            if (jobPosting1 != null)
            {
                // Auto update and save to DB
                jobPosting1.JobPostingTitle = jobPosting.JobPostingTitle;
                jobPosting1.Description = jobPosting.Description;
                jobPosting1.PostedDate = jobPosting.PostedDate;
                save();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }

    }
}
