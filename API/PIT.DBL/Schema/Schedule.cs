using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Schedule
    {
        public int ID {get;set;}
        public int CompanyId { get; set; }
        public DateTime ScheduleDate { get; set; }        
        public string ActivityName { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public string ActivityDetail { get; set; }
        public int CreatedBy {get;set;}
        public DateTime CreatedDate {get;set;}
        public int ModifiedBy {get;set;}
        public string Status {get;set; }
    }
}