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
    public class GurudwaraService : IGurudwaraServices
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<GurudwaraServices> dbSet;

        public GurudwaraService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<GurudwaraServices>();
        }

       public ResultModel GetAll(ApplicationUser AppUser)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                oOutput.Data = dbSet.Where(t=>t.CompanyId==AppUser.CompanyID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;

        }

        public ResultModel Insert(GurudwaraServicesModel obj, ApplicationUser AppUser)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                GurudwaraServices oServices = dbSet.Where(t => t.CompanyId == AppUser.CompanyID).FirstOrDefault();
                if (oServices == null)
                {
                    oServices = new GurudwaraServices();
                    obj.CreatedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
                    obj.CreatedDate = DateTime.Now;
                    obj.CompanyId = AppUser.CompanyID;
                    GurudwaraServices oUser = Mapper.Map<GurudwaraServices>(obj);
                    dbSet.Add(oServices);
                }
                else
                {
                    oServices.ModifiedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
                    oServices.ModifiedDate = DateTime.Now;
                    oServices.ServicesDescription=obj.ServicesDescription;
                }

                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<GurudwaraServicesModel>(oServices);
            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = ex.Message;
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }
    }
}
