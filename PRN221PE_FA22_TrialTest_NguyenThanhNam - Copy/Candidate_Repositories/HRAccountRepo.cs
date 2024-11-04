using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;
using Candidate_DAOs;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        // Short code to impl DAO
        public Hraccount GetHraccountByEmail(string email)
            => HRAccountDAO.Instance.GetHraccountByEmail(email);
        // Short code to impl DAO
        public List<Hraccount> GetHraccounts()
            => HRAccountDAO.Instance.GetHraccounts();
    }
}
