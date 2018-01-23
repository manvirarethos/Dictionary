using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class StoreRoom
    {

        public int ID { get; set; }
        public int CompanyID {get;set;}
        public string Name { get; set; }
        public int Totalfloor { get; set; }
        public bool  Status { get; set; }

    }
}
