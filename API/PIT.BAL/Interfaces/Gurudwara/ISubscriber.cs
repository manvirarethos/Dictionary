using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface ISubscriber
    {
        ResultModel Register(subscriberModel obj);

        ResultModel ResendCode(subscriberModel obj);
        ResultModel VerifyCode(subscriberModel obj,int CompanyId);
    }
}
