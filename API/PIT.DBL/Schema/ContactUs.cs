using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class ContactUs
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string ContactUsDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}