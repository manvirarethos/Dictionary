using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
  public  class ActivityModel
    {
        public int ID {get;set;}
        public int CompanyId { get; set; }
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