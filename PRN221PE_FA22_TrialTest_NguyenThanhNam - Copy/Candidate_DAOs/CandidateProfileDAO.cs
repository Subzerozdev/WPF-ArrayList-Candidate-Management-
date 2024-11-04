using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO : CandidateProfile
    {
        private static CandidateProfileDAO? instance = null;
        private List<CandidateProfile>? _candidateProfiles;
        private string _filepath = "D:\\C#_Practice_PE\\PRN221_TrialTest\\PRN221PE_FA22_TrialTest_NguyenThanhNam - Copy\\CandidateManagement_NguyenThanhNam\\File\\CandidateProfile.xml";
        public CandidateProfileDAO()
        {
            _candidateProfiles = ReadCandidateProfiles();
        }

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
        // Read all contacts by xml
        public List<CandidateProfile> ReadCandidateProfiles()
        {
            XDocument xdoc = XDocument.Load(_filepath);
            return (from candidate in xdoc.Descendants("CandidateProfile")
                    select new CandidateProfile
                    {
                        CandidateId = candidate.Element("CandidateId")?.Value ?? string.Empty,
                        Fullname = candidate.Element("Fullname")?.Value ?? string.Empty,
                        Birthday =DateTime.TryParse(candidate.Element("Birthday")?.Value, out var birthday)? birthday: default(DateTime),
                        ProfileShortDescription = candidate.Element("ProfileShortDescription")?.Value ?? string.Empty,
                        ProfileUrl = candidate.Element("ProfileUrl")?.Value ?? string.Empty,
                        PostingId = candidate.Element("PostingId")?.Value ?? string.Empty
                    }).ToList();
        }
        // Save to xml file
        private void save()
        {
            // Serialize the list to XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<CandidateProfile>), new XmlRootAttribute("Candidates"));
            using (TextWriter writer = new StreamWriter(_filepath))
            {
                serializer.Serialize(writer, _candidateProfiles);
            }
        }
        // Get all Candidates
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return _candidateProfiles;
        }
        // Get Candidate by ID
        public CandidateProfile? GetCandidateProfile(string id)
        {
            CandidateProfile? candidate = _candidateProfiles.FirstOrDefault(c=>c.CandidateId.Equals(id));
            return candidate;
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                _candidateProfiles.Add(candidateProfile);
                save();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }
        // Delete Candidate
        public bool DeleteCandidateProfile(string candidateID)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                _candidateProfiles.Remove(candidate);
                save();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }
        // Update Candidate
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = _candidateProfiles.FirstOrDefault(c => c.CandidateId.Equals(candidateProfile.CandidateId));
            if (candidate != null)
            {
                candidate.Fullname = candidateProfile.Fullname;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.PostingId = candidateProfile.PostingId;
                save();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }



    }
}
