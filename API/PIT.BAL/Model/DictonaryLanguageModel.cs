using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
  public  class DictonaryLanguageModel
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string LanguageCode { get; set; }
        public int DictonaryID { get; set; }
        public string Word { get; set; }
    }
}
