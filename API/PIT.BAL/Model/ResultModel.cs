using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
    public class ResultModel
    {
        public object Data { get; set; }
         public int Status { get; set; }
        public string Msg { get; set; }

        public ResultModel()
        {
            Status = 1;
            Msg = "OK";
        }

    }
}
