using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class StoreGadderModel
    {

        public int ID { get; set; }
        public int RoomID {get;set;}
       
        public int Capacity { get; set; }
        public bool  Status { get; set; }

    }
}
