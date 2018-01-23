using PIT.BAL.Interfaces;
using System;
using PIT.BAL.Model;
using PIT.DBL.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace PIT.BAL.Services
{
    public class MenuService : IMenu
    {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Menu> dbSet;

        public MenuService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Menu>();
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
                oOutput.Data = dbSet.Include("Task").ToList();

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

        public ResultModel Insert(MenuModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Menu oUser = Mapper.Map<Menu>(obj);
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

        public ResultModel Update(MenuModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                Menu oUser = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
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
