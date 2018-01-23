using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface IActivity

    {
        ResultModel GetAll(ApplicationUser AppUser);
        ResultModel GetById(int Id, ApplicationUser AppUser);
        ResultModel Insert(ActivityModel obj, ApplicationUser AppUser);
        ResultModel Update(ActivityModel obj, ApplicationUser AppUser);
        ResultModel Delete(int Id, ApplicationUser AppUser);
    }
}