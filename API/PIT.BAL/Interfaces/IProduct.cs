using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IProduct
    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(ProductModel obj);
        ResultModel Update(ProductModel obj);
        ResultModel Delete(int Id);
    }
}
