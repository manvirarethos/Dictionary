using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IRole

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(RoleModel obj);
        ResultModel Update(RoleModel obj);
        ResultModel Delete(int Id);
    }
}
