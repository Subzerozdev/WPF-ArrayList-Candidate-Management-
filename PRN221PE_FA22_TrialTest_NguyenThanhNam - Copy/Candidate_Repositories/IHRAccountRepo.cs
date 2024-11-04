using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Candidate_BusinessObjects;

namespace Candidate_Repositories
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(String email);
        public List<Hraccount> GetHraccounts();
    }
}
