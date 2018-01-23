using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Role
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool  Enabled { get; set; }
        public UserType RoleForType { get; set; }

        public List<RoleTask> Tasks { get; set; }
    }
}
