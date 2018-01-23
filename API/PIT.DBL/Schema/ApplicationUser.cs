using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
 public   class ApplicationUser :BaseScheme
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
        public int CompanyID { get; set; }
        public UserStatus Status { get; set; }
        public virtual Company Company { get; set; }
        public ApplicationUser() { LastLoginTime = DateTime.Now; }

    }

    public enum UserType
    {
        SystemAdmin,
        SystemUser,
        CompanyAdmin,
        CompanyUser,
        CustomerAdmin,
        CustomerUser
    }

    public enum UserStatus
    {
        Deleted=-1,
        Inactive=0,
        Active=1
    }
}
