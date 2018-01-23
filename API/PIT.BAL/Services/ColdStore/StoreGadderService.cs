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
    public class StoreGadderService : IStoreGadder
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<StoreGadder> dbSet;

        public StoreGadderService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<StoreGadder>();
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
                    oDB.StoreGadder.Remove(oReoord);
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
                oOutput.Data = Mapper.Map<List<StoreGadderModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<StoreGadder>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(StoreGadderModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                StoreGadder oStoreGadder = Mapper.Map<StoreGadder>(obj);
                dbSet.Add(oStoreGadder);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<StoreGadderModel>(oStoreGadder);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(StoreGadderModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                StoreGadder oStoreGadder = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oStoreGadder == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oStoreGadder);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<StoreGadder>(oStoreGadder);
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
