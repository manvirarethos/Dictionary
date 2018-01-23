using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IMenu
    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(MenuModel obj);
        ResultModel Update(MenuModel obj);
        ResultModel Delete( int Id);


    }
}
