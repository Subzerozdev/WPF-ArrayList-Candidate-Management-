using System;
using System.Collections.Generic;

namespace Candidate_BusinessObjects
{
    public partial class Hraccount
    {
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public int? MemberRole { get; set; }


        public Hraccount() { }

        public Hraccount(string email, string? password, string? fullName, int? memberRole)
        {
            Email = email;
            Password = password;
            FullName = fullName;
            MemberRole = memberRole;
        }
    }
}
