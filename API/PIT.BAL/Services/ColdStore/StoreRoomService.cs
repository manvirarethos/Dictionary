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
    public class StoreRoomService : IStoreRoom
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<StoreRoom> dbSet;

        public StoreRoomService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<StoreRoom>();
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
                    oDB.StoreRoom.Remove(oReoord);
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
                oOutput.Data = Mapper.Map<List<StoreRoomModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<StoreRoom>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(StoreRoomModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                StoreRoom oStoreRoom = Mapper.Map<StoreRoom>(obj);
                dbSet.Add(oStoreRoom);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<StoreRoomModel>(oStoreRoom);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(StoreRoomModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                StoreRoom oStoreRoom = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oStoreRoom == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oStoreRoom);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<StoreRoom>(oStoreRoom);
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
