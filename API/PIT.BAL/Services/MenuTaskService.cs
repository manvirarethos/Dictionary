using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIT.BAL.Services
{
   public class MenuTaskService : IMenuTask
    {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<MenuTask> dbSet;

        public MenuTaskService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<MenuTask>();
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



        public ResultModel GetById(int Id)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = dbSet.Where(m=>m.ID==Id).FirstOrDefault();
                if (oOutput.Data==null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Sorry, Record not exist";
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

        public ResultModel Insert(MenuTaskModel obj)
        {


           


            ResultModel oOutput = new ResultModel();

            try
            {
                MenuTask oUser = Mapper.Map<MenuTask>(obj);
                dbSet.Add(oUser);
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

        public ResultModel Update(MenuTaskModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                MenuTask oUser = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUser == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    oUser = Mapper.Map(obj, oUser);
                    oDB.SaveChanges();
                }
                oOutput.Data = oUser;
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
