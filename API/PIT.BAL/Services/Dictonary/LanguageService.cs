using PIT.BAL.Interfaces.Dictonary;
using System;
using PIT.BAL.Model;
using PIT.DBL.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace PIT.BAL.Services.Dictonary
{
    public class LanguageService : ILanguage
    {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Language> dbSet;

        public LanguageService(DBL.ApplicationDBContext _oDB)
        {  
            oDB = _oDB;
            dbSet = oDB.Set<Language>();
        }

        public ResultModel Delete(int Id)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Language oReoord = dbSet.Where(m => m.ID == Id).FirstOrDefault();
                if (oReoord != null)
                {
                    dbSet.Remove(oReoord);
                    oDB.SaveChanges();
                    oOutput.Status = 1;
                    oOutput.Msg = "done";
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

         public ResultModel GetActive()
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = dbSet.Where(m=>m.Status==true).ToList();

            }
            catch (Exception ex)
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
                oOutput.Data = dbSet.Where(m=>m.ID==Id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(LanguageModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Language oLanguage = Mapper.Map<Language>(obj);
                dbSet.Add(oLanguage);
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

        public ResultModel Update(LanguageModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                Language oLanguage = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oLanguage == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    oLanguage = Mapper.Map(obj, oLanguage);
                    oDB.SaveChanges();
                }
                oOutput.Data = oLanguage;
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
