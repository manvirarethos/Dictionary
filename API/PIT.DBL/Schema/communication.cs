using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class communication
    {
        public int ID { get; set; }
        public string SentTo { get; set; }

        public DateTime WhenToSend { get; set; }

        public DateTime SentTime { get; set; }

        public int CommunicationStatusID { get; set; }

        public int AlertTypeID { get; set; }

        public string Subject { get; set; }

        public string Contents { get; set; }

        public string ServiceRemarks { get; set; }

        public DateTime CreatedDate { get; set; }
      //  public virtual communicationstatus communicationstatus { get; set; }
      //  public virtual alertype alertype { get; set; }
    }
}
