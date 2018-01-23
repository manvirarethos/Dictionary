using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
    public class ApplicationUserModel : BaseScheme
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int CompanyId { get; set; }
        public UserStatus Status { get; set; }      
        public List<UserRole> Roles { get; set; }
    }
}