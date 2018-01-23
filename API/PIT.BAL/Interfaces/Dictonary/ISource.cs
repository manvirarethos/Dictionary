using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces.Dictonary
{
    public interface ISource
    {
        ResultModel GetAll();
        ResultModel GetActive();
        ResultModel GetById( int Id);
        ResultModel Insert(SourceModel obj);
        ResultModel Update(SourceModel obj);
        ResultModel Delete( int Id);


    }
}
