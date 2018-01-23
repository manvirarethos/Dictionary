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
    public class ScheduleService : ISchedule
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Schedule> dbSet;

        public ScheduleService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Schedule>();
        }
        public ResultModel Delete(int Id, ApplicationUser AppUser)
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
                else
                {
                    dbSet.Remove(oReoord);
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

        public ResultModel GetAll(ApplicationUser AppUser)
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



        public ResultModel GetById(int Id, ApplicationUser AppUser)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = Mapper.Map<ScheduleModel>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(ScheduleModel obj, ApplicationUser AppUser)
        {

            ResultModel oOutput = new ResultModel();

            try
            {

                Schedule oUser = Mapper.Map<Schedule>(obj);
                dbSet.Add(oUser);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<ScheduleModel>(oUser);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(ScheduleModel obj, ApplicationUser AppUser)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                // Deleting UnSelected 
                //List<ScheduleTask> ToDelete = oDB.ScheduleTask.Where(m => m.ScheduleID == obj.ID && !obj.Schedule.Where(v => v.ID != 0).Select(x => x.ID).Contains(m.ID)).ToList();
                //oDB.ScheduleTask.RemoveRange(ToDelete);
                //oDB.SaveChanges();


                Schedule oUser = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUser == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {

                    Mapper.Map(obj, oUser);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<ScheduleModel>(oUser);
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
