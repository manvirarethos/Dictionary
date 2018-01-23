using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class PlansModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Mode { get; set; }
        public double Rate { get; set; }
        public int CompanyID { get; set; }
    }
}
