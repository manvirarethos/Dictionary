using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface ICompany

    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(CompanyModel obj);
        ResultModel Update(CompanyModel obj);
        ResultModel Delete(int Id);
    }
}
