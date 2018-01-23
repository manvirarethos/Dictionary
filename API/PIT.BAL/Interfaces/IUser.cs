using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IUser

    {
       // ResultModel GetAll();
       
       // ResultModel GetById( int Id);
        ResultModel Insert(UserModel obj);
       // ResultModel Update(UserModel obj);
      //  ResultModel Delete(int Id);
    }
}
