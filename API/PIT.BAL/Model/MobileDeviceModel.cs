using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
    public class MobileDeviceModel
    {
        public string cordova { get; set; }
        public string model { get; set; }
        public string platform { get; set; }
        public string uuid { get; set; }

        public string version { get; set; }

        public string  manufacturer { get; set; }

         public Boolean  isVirtual { get; set; }

         public string serial { get; set; }
    }

}
