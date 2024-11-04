using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private List<Hraccount> hraccounts;

        private static HRAccountDAO instance = null;

        public HRAccountDAO()
        {
            Hraccount hraccount1 = new("admin@hr.com.vn", "123@", "Admin HR", 1);
            Hraccount hraccount2 = new("manager@hr.com.vn", "123@", "Manager HR", 2);
            Hraccount hraccount3 = new("staff@hr.com.vn", "123", "Staff HR", 3);
            hraccounts = new List<Hraccount>(); 
            hraccounts.Add(hraccount1);
            hraccounts.Add(hraccount2);
            hraccounts.Add(hraccount3);
        }

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();

                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(String email)
        {
            return hraccounts.FirstOrDefault(h =>h.Email.Equals(email));
        }
        public List <Hraccount>   GetHraccounts ()
        {
            return hraccounts;
        }
    }
}
