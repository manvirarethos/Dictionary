using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model {

        public class DictonaryModel {

        public int ID { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public List<DictonaryLanguageModel> DictonaryLanguage { get; set; }
        public List<DictonarySourceModel> DictonarySource { get; set; }

    }

}