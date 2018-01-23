using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Language
    {

        public int ID { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
        public bool Status { get; set; }
    }
}
