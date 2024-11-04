using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {

        private List<CandidateProfile> _profiles;

        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfileDAO()
        {
            CandidateProfile candidateProfile01 = new CandidateProfile("CANDIDATE0001", "Danh", new DateTime(), "Excellent communication skills ", "AlanClinton.PDF", "P0001");
            CandidateProfile candidateProfile02 = new CandidateProfile("CANDIDATE0002", "Khanh", new DateTime(), "Excellent soft skills ", "AlanClinton.PDF", "P0002");
            CandidateProfile candidateProfile03 = new CandidateProfile("CANDIDATE0003", "Nam", new DateTime(), "Good Java ", "AlanClinton.PDF", "P0003");
            CandidateProfile candidateProfile04 = new CandidateProfile("CANDIDATE0004", "Tien", new DateTime(), "Intermediate NET skills ", "AlanClinton.PDF", "P0002");
            CandidateProfile candidateProfile05 = new CandidateProfile("CANDIDATE0005", "Thanh", new DateTime(), "Excellent NodeJs skills ", "AlanClinton.PDF", "P0003");
            List<CandidateProfile> profiles = new List<CandidateProfile>();
            profiles.Add(candidateProfile01);
            profiles.Add(candidateProfile02);
            profiles.Add(candidateProfile03);
            profiles.Add(candidateProfile04);
            profiles.Add(candidateProfile05);
            _profiles = profiles;
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            
            return _profiles;
        }
        public CandidateProfile GetCandidateProfile(string id)
        {
            return _profiles.FirstOrDefault(p => p.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                _profiles.Add(candidateProfile);
                isSuccess = true;
            }
            return isSuccess;

        }

        public bool DeleteCandidateProfile(string candidateID)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                _profiles.Remove(candidate);
                isSuccess = true;
            }
            return isSuccess;

        }


        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = _profiles.FirstOrDefault(p => p.CandidateId.Equals(candidateProfile.CandidateId));
            if (candidate != null)
            {
                //dbContext.Entry<CandidateProfile>(candidateProfile).State = 
                //    Microsoft.EntityFrameworkCore.EntityState.Modified;

                candidate.Fullname = candidateProfile.Fullname;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.PostingId = candidateProfile.PostingId;



                isSuccess = true;
            }
            return isSuccess;

        }




    }
}
