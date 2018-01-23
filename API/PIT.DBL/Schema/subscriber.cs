using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class subscriber
    {
        public subscriber()
        {
             CreatedOn= DateTime.Now;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string GurudwaraCode { get; set; }
        public Boolean IsVerified { get; set; }

        public DateTime CreatedOn { get; set; }

        public string DeviceId { get; set; }

        public string VerificationCode { get; set; }
    }
}
