using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
  public  class DictonarySourceModel
    {
        public int ID { get; set; }
        public int SourceID { get; set; }
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public int DictonaryID { get; set; }
        public string WordMeaning { get; set; }
        public string Translation { get; set; }
    }
}
