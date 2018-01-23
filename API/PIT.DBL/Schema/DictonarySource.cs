using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class DictonarySource
    {

        public int ID { get; set; }
        public int SourceID { get; set; }
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public int DictonarytbID { get; set; }
        public string WordMeaning { get; set; }
        public string Translation { get; set; }
        public virtual Dictonarytb Dictonarytb { get; set; }
    }
}
