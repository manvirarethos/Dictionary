using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class UserRole
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }

        public virtual Role Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
