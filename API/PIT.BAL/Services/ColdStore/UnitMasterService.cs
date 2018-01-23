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
    public class UnitMasterService : IUnitMaster
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<UnitMaster> dbSet;

        public UnitMasterService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<UnitMaster>();
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
                    oDB.UnitMaster.Remove(oReoord);
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
                oOutput.Data = Mapper.Map<List<UnitMasterModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<UnitMasterModel>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(UnitMasterModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                UnitMaster oUnitMaster = Mapper.Map<UnitMaster>(obj);
                dbSet.Add(oUnitMaster);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<UnitMasterModel>(oUnitMaster);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(UnitMasterModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                UnitMaster oUnitMaster = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUnitMaster == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oUnitMaster);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<UnitMasterModel>(oUnitMaster);
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
