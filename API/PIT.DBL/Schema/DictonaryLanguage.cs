using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class DictonaryLanguage
    {

        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public int DictonarytbID { get; set; }
        public string Word { get; set; }
        //public virtual Dictonarytb Dictonarytb { get; set; }
    }
}
