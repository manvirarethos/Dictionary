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
    // public class ContactUsService : IContactUs
    // {

    //     private DBL.ApplicationDBContext oDB = null;
    //     private DbSet<ContactUs> dbSet;

    //     public ContactUsService(DBL.ApplicationDBContext _oDB)
    //     {
    //         oDB = _oDB;
    //         dbSet = oDB.Set<ContactUs>();
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

    //     public ResultModel Insert(ContactUsModel obj, ApplicationUser AppUser)
    //     {
    //         ResultModel oOutput = new ResultModel();
    //         try
    //         {
    //             ContactUs oContactUs = dbSet.Where(t => t.CompanyId == AppUser.CompanyID).FirstOrDefault();
    //             if (oContactUs == null)
    //             {
    //                 oContactUs = new ContactUs();
    //                 obj.CreatedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
    //                 obj.CreatedDate = DateTime.Now;
    //                 obj.CompanyId = AppUser.CompanyID;
    //                 ContactUs oUser = Mapper.Map<ContactUs>(obj);
    //                 dbSet.Add(oUser);
    //             }
    //             else
    //             {
    //                 oContactUs.ModifiedBy = AppUser.CreatedID == null ? 0 : AppUser.CreatedID.Value;
    //                 oContactUs.ModifiedDate = DateTime.Now;
    //                 oContactUs.ContactUsDescription=obj.ContactUsDescription;
    //             }

    //             oDB.SaveChanges();
    //             oOutput.Data = Mapper.Map<ContactUsModel>(oContactUs);
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
