using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IUnitMaster

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(UnitMasterModel obj);
        ResultModel Update(UnitMasterModel obj);
        ResultModel Delete(int Id);
    }
}
