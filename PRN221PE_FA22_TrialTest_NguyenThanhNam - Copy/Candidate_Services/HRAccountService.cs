using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountService
    {
        // Repo Interface
        private IHRAccountRepo iAccountRepo;
        // Ctor
        public HRAccountService() { 
            iAccountRepo = new HRAccountRepo();
        }
        // Service
        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return iAccountRepo.GetHraccounts();
        }
    }
}
