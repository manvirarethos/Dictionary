using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IStoreRoom

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(StoreRoomModel obj);
        ResultModel Update(StoreRoomModel obj);
        ResultModel Delete(int Id);
    }
}
