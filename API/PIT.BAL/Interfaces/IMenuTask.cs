using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IMenuTask
    {
        ResultModel GetAll();
     
        ResultModel GetById( int Id);
        ResultModel Insert(MenuTaskModel obj);
        ResultModel Update(MenuTaskModel obj);
        ResultModel Delete(int Id);
    }
}
