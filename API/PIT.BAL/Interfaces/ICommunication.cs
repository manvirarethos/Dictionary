using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface ICommunication
    {
        ResultModel SendCommunication(CommunicationModel obj);
    }
}
