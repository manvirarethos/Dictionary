using PIT.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PIT.BAL.Model;
using Microsoft.EntityFrameworkCore;
using PIT.DBL.Schema;
using System.Linq;
using AutoMapper;

namespace PIT.BAL.Services
{
    public class PlansService : IPlans
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Plans> dbSet;

        public PlansService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Plans>();
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
                }else{
                    oDB.Plans.Remove(oReoord);
                    oDB.SaveChanges();
                    
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
                oOutput.Data = Mapper.Map<List<PlansModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<PlansModel>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(PlansModel obj,ApplicationUser appUser)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
               // obj.CompanyID = appUser.CompanyId;
                Plans oPlans = Mapper.Map<Plans>(obj);
                dbSet.Add(oPlans);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<PlansModel>(oPlans);

            }
            catch (Exception ex)
            {
                oOutput.Data = obj;
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(PlansModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                Plans oPlans = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oPlans == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oPlans);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<PlansModel>(oPlans);
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
    }
}
