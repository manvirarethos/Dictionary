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
    public class UserService : IUser
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<ApplicationUser> dbSet;

        public UserService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<ApplicationUser>();
        }
      

        public ResultModel Insert(UserModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {   
                ApplicationUser ouser = new ApplicationUser();
                ouser.FirstName = obj.FirstName;
                ouser.LastName = obj.LastName;
                ouser.ContactNumber = obj.ContactNumber;
                ouser.UserName = obj.UserName;
                ouser.EmailAddress = obj.EmailAddress;
                ouser.Password = obj.Password;
            // ouser.UserType = obj.UserType;
        //    ouser.Status = obj.Status;
                dbSet.Add(ouser);
                oDB.SaveChanges();
                oOutput.Data = ouser;

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
