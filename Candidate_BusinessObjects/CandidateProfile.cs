using System;
using System.Collections.Generic;

namespace Candidate_BusinessObjects
{
    public  class CandidateProfile
    {
        public string CandidateId { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? ProfileShortDescription { get; set; }
        public string? ProfileUrl { get; set; }
        public string? PostingId { get; set; }

        public CandidateProfile(string candidateId, string fullname, DateTime? birthday, string? profileShortDescription, string? profileUrl, string? postingId)
        {
            CandidateId = candidateId;
            Fullname = fullname;
            Birthday = birthday;
            ProfileShortDescription = profileShortDescription;
            ProfileUrl = profileUrl;
            PostingId = postingId;
        }

        public CandidateProfile()
        {
            
        }
    }
}
