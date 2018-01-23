using PIT.BAL.Interfaces.Dictonary;
using System;
using PIT.BAL.Model;
using PIT.DBL.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace PIT.BAL.Services.Dictonary
{
    public class DictonaryService : IDictonary
    {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Dictonarytb> dbSet;

        public DictonaryService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Dictonarytb>();
        }

        public ResultModel AutoSearch(string query)
        {
            ResultModel oModel = new ResultModel();
            oModel.Data = dbSet.Where(m => m.Word.StartsWith(query)).OrderBy(m => m.Word).Select(m => new SelectListModel {ID= m.ID, Name = m.Word }).ToList();
            return oModel;
        }

        public ResultModel Delete(int Id)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                var oReoord = dbSet.Where(m => m.ID == Id).FirstOrDefault();
                if (oReoord == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Sorry, No record exist";
                }
            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;

        }

        public ResultModel GetAll()
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = dbSet.ToList();

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;

        }

        public ResultModel GetAllLanguage()
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = oDB.Language.ToList();
            }
            catch (System.Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }
        public ResultModel GetById(int Id)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = dbSet.ToList();

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(DictonaryModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Dictonarytb oDictonary = Mapper.Map<Dictonarytb>(obj);
                dbSet.Add(oDictonary);
                oDB.SaveChanges();

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Search(string query, int pageIndex, int PageSize)
        {
            ResultModel oModel = new ResultModel();
            oModel.Data = PaginatedList<Dictonarytb>.CreateAsync((dbSet.Where(m => m.Word.StartsWith(query)).OrderBy(m => m.Word)), pageIndex, PageSize);
            return oModel;

        }

        public ResultModel SearchWord(string query, int page)
        {
            ResultModel oModel = new ResultModel();
           
            oModel.Data = dbSet.Include("DictonaryLanguage").Include("DictonarySource").Where(m => m.ID==page).FirstOrDefault();
            return oModel;
        }
        public ResultModel SearchWord(string query)
        {
            ResultModel oModel = new ResultModel();

            oModel.Data = dbSet.Include("DictonaryLanguage").Include("DictonarySource").Where(m => m.Word == query).FirstOrDefault();
            return oModel;
        }
        public ResultModel Update(DictonaryModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                Dictonarytb oDictonary = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oDictonary == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    oDictonary = Mapper.Map(obj, oDictonary);
                    oDB.SaveChanges();
                }
                oOutput.Data = oDictonary;
            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }
    }
}
