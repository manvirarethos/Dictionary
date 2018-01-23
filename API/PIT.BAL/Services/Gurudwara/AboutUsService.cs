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
    // public class AboutUsService : IAboutUs
    // {

    //     private DBL.ApplicationDBContext oDB = null;
    //     private DbSet<AboutUs> dbSet;

    //     public AboutUsService(DBL.ApplicationDBContext _oDB)
    //     {
    //         oDB = _oDB;
    //         dbSet = oDB.Set<AboutUs>();
    //     }

    //    public ResultModel GetAll(ApplicationUser AppUser)
    //     {
    //         ResultModel oOutput = new ResultModel();
    //         try
    //         {
    //             oOutput.Data = dbSet.Where(t=>t.CompanyId==AppUser.CompanyID).FirstOrDefault();
    //         }
    //         catch (Exception ex)
    //         {
    //             oOutput.Status = 0;
    //             oOutput.Msg = "Data access error";
    //             Services.Utitilty.Error(ex);
    //         }
    //         return oOutput;

    //     }

    //     public ResultModel Insert(AboutUsModel obj, ApplicationUser AppUser)
    //     {
    //         ResultModel oOutput = new ResultModel();
    //         try
    //         {
    //             AboutUs oAboutUs = dbSet.Where(t => t.CompanyId == AppUser.CompanyID).FirstOrDefault();
    //             if (oAboutUs == null)
    //             {
    //                 oAboutUs = new AboutUs();
    //                 obj.CreatedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
    //                 obj.CreatedDate = DateTime.Now;
    //                 obj.CompanyId = AppUser.CompanyID;
    //                 AboutUs oUser = Mapper.Map<AboutUs>(obj);
    //                 dbSet.Add(oUser);
    //             }
    //             else
    //             {
    //                 oAboutUs.ModifiedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
    //                 oAboutUs.ModifiedDate = DateTime.Now;
    //                 oAboutUs.AboutUsDescription=obj.AboutUsDescription;
    //             }

    //             oDB.SaveChanges();
    //             oOutput.Data = Mapper.Map<AboutUsModel>(oAboutUs);
    //         }
    //         catch (Exception ex)
    //         {
    //             oOutput.Status = 0;
    //             oOutput.Msg = ex.Message;
    //             Services.Utitilty.Error(ex);
    //         }
    //         return oOutput;
    //     }
    // }
}
