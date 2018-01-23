using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
  public  class RoleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public UserType RoleForType { get; set; }

        public List<RoleTaskModel> Tasks { get; set; }
    }

}
