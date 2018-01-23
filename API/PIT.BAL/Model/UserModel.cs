using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
     public class UserModel : BaseScheme
    {
        public int CompanyId { get; set; }
        public string ContactNumber { get; set; }
        public int CreatedId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Hash { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }

    }

}
