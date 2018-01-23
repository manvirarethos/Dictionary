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
    public class StoreFloorService : IStoreFloor
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<StoreFloor> dbSet;

        public StoreFloorService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<StoreFloor>();
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
                    oDB.StoreFloor.Remove(oReoord);
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
                oOutput.Data = Mapper.Map<List<StoreFloorModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<StoreFloor>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(StoreFloorModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                StoreFloor oStoreFloor = Mapper.Map<StoreFloor>(obj);
                dbSet.Add(oStoreFloor);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<StoreFloorModel>(oStoreFloor);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(StoreFloorModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                StoreFloor oStoreFloor = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oStoreFloor == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oStoreFloor);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<StoreFloor>(oStoreFloor);
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
