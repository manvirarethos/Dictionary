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
    public class ActivityService : IActivity
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Activity> dbSet;

        public ActivityService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Activity>();
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
                oOutput.Data = Mapper.Map<ActivityModel>(dbSet.Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(ActivityModel obj, ApplicationUser AppUser)
        {

            ResultModel oOutput = new ResultModel();

            try
            {

                Activity oUser = Mapper.Map<Activity>(obj);
                dbSet.Add(oUser);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<ActivityModel>(oUser);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(ActivityModel obj, ApplicationUser AppUser)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                // Deleting UnSelected 
                //List<ActivityTask> ToDelete = oDB.ActivityTask.Where(m => m.ActivityID == obj.ID && !obj.Activity.Where(v => v.ID != 0).Select(x => x.ID).Contains(m.ID)).ToList();
                //oDB.ActivityTask.RemoveRange(ToDelete);
                //oDB.SaveChanges();


                Activity oUser = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUser == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {

                    Mapper.Map(obj, oUser);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<ActivityModel>(oUser);
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
