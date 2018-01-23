using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Source
    {

        public int ID { get; set; }
        public string SourceName { get; set; }
        public string SourceCode { get; set; }
        public bool Status { get; set; }
    }
}
