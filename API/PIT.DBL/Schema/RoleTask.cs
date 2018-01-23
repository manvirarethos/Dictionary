using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class RoleTask
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int MenuTaskID { get; set; }

        public virtual Role Role { get; set; }
        public virtual MenuTask MenuTask { get; set; }
    }
}
