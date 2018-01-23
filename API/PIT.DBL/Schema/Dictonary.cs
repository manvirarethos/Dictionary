using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Dictonarytb
    {

        public int ID { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public List<DictonaryLanguage> DictonaryLanguage {get;set;}
        public List<DictonarySource> DictonarySource {get;set;}
    }
}
