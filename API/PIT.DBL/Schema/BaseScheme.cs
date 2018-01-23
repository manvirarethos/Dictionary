using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class BaseScheme
    {
        public int ID { get; set; }
        public DateTime? CreatedOn{ get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedID { get; set; }
        public int? ModifiedID { get; set; }
       public BaseScheme()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

    }
}
