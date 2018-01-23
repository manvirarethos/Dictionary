using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Company
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool Enabled { get; set; }
    }
}
