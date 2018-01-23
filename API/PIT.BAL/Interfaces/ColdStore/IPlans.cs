using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IPlans

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(PlansModel obj,ApplicationUser appUser);
        ResultModel Update(PlansModel obj);
        ResultModel Delete(int Id);
    }
}
