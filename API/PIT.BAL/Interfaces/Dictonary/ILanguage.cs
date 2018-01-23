using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces.Dictonary
{
    public interface ILanguage
    {
        ResultModel GetAll();
        ResultModel GetActive();
        ResultModel GetById( int Id);
        ResultModel Insert(LanguageModel obj);
        ResultModel Update(LanguageModel obj);
        ResultModel Delete( int Id);


    }
}
