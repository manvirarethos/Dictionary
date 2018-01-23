using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IStoreFloor

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(StoreFloorModel obj);
        ResultModel Update(StoreFloorModel obj);
        ResultModel Delete(int Id);
    }
}
