using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Candidate_BusinessObjects;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private List<Hraccount> _accounts;
        private string _filepath = "D:\\C#_Practice_PE\\PRN221_TrialTest\\PRN221PE_FA22_TrialTest_NguyenThanhNam - Copy\\CandidateManagement_NguyenThanhNam\\File\\Account.xml";
        // DAO instance
        private static HRAccountDAO? instance = null;
        public HRAccountDAO()
        {
            _accounts = ReadAccounts();
        }
        // Something
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
        // Read all Account by xml
        public List<Hraccount> ReadAccounts()
        {
            XDocument xdoc = XDocument.Load(_filepath);
            return (from account in xdoc.Descendants("Account")
                    select new Hraccount
                    {
                        Email = account.Element("Email")?.Value ?? string.Empty,
                        Password = account.Element("Password")?.Value ?? string.Empty,
                        FullName = account.Element("FullName")?.Value ?? string.Empty,
                        MemberRole = int.Parse(account.Element("MemberRole")?.Value),
                    }).ToList();
        }
        // Get account by email 
        public Hraccount? GetHraccountByEmail(String email)
        {
            return _accounts.FirstOrDefault(x => x.Email.Equals(email)); ;
        }
        // Get all accounts
        public List<Hraccount> GetHraccounts()
        {
            return _accounts;
        }
    }
}
