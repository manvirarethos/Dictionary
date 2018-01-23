using PIT.BAL.Interfaces;
using System;
using PIT.BAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PIT.DBL.Schema;
using AutoMapper;

namespace PIT.BAL.Services
{
    public class Auth : IAuth
    {
        private DBL.ApplicationDBContext db = null;
        private DbSet<ApplicationUser> dbSet;

        public Auth(DBL.ApplicationDBContext _oDB)
        {
            db = _oDB;
            dbSet = db.Set<ApplicationUser>();
        }
        public ResultModel ChangePassword(ChangePasswordModel obj)
        {
            throw new NotImplementedException();
        }

        public ResultModel Delete(int Id)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                var oReoord = dbSet.Where(m => m.ID == Id && m.Status != UserStatus.Deleted).FirstOrDefault();
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
                if (oOutput.Data == null)
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

        public ResultModel Insert(ApplicationUserModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                ApplicationUser oUser = Mapper.Map<ApplicationUser>(obj);
                dbSet.Add(oUser);
                db.SaveChanges();
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

        public ResultModel Update(ApplicationUserModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                ApplicationUser oUser = dbSet.Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUser == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    oUser = Mapper.Map<ApplicationUserModel, ApplicationUser>(obj, oUser);
                    db.SaveChanges();
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

        public ResultModel VerifyUser(LoginModel obj)
        {
            ApplicationUser oUser = dbSet.Where(m => m.UserName == obj.UserName && m.Password == obj.Password).FirstOrDefault();
            ResultModel oOutput = new ResultModel();
            if (oUser == null)
            {
                oOutput.Data = oUser;
                oOutput.Status = 0;
                oOutput.Msg = "Username/password failed ...";
            }
            else
            {
                oOutput.Data = oUser;
                oOutput.Status = 1;
                oOutput.Msg = "Loged in successfully ...";
            }
            return oOutput;
        }
    }
}
