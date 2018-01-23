using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IStoreGadder

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(StoreGadderModel obj);
        ResultModel Update(StoreGadderModel obj);
        ResultModel Delete(int Id);
    }
}
