using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class UnitMaster
    {

        public int ID { get; set; }
        public string Name { get; set; }  
        public string Type {get;set;}
        public int Volume{get;set;}
        public bool Status {get;set;}
    }
}
