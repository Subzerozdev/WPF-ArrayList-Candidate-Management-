using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        // Get all Candidates
        public List<CandidateProfile> GetCandidateProfiles();
        // Get Candidate by ID
        public CandidateProfile GetCandidateProfile(string id);
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        // Delete Candidate
        public bool DeleteCandidateProfile(string candidateID);
        // Update Candidate
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
