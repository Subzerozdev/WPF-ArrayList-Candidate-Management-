using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        // Repo
        private readonly ICandidateProfileRepo profileRepo;
        // ctor
        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(string candidateID)
        {
           return profileRepo.DeleteCandidateProfile(candidateID);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return profileRepo.GetCandidateProfile(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return profileRepo.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(candidateProfile);
        }
    }
}
