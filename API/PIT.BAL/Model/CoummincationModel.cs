using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
    public class CommunicationModel
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

    }
}
