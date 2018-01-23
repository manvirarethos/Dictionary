using PIT.BAL.Interfaces.Dictonary;
using System;
using PIT.BAL.Model;
using PIT.DBL.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace PIT.BAL.Services.Dictonary
{
    public class SourceService : ISource
    {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Source> dbSet;

        public SourceService(DBL.ApplicationDBContext _oDB)
        {  
            oDB = _oDB;
            dbSet = oDB.Set<Source>();
        }

        public ResultModel Delete(int Id)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                var oReoord = dbSet.Where(m => m.ID == Id ).FirstOrDefault();
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

        public ResultModel Insert(SourceModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Source oSource = Mapper.Map<Source>(obj);
                dbSet.Add(oSource);
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

        public ResultModel Update(SourceModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                Source oSource = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oSource == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    oSource = Mapper.Map(obj, oSource);
                    oDB.SaveChanges();
                }
                oOutput.Data = oSource;
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
