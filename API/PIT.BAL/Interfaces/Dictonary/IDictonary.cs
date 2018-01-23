using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces.Dictonary
{
    public interface IDictonary
    {
        ResultModel GetAll();
       
        ResultModel GetById( int Id);
        ResultModel Insert(DictonaryModel obj);
        ResultModel Update(DictonaryModel obj);
        ResultModel Delete( int Id);
        ResultModel GetAllLanguage();
        ResultModel Search(string query,int page,int PageSize);
        ResultModel SearchWord(string query, int page);
        ResultModel SearchWord(string query);
        ResultModel AutoSearch(string query);

    }
}
