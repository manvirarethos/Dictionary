using PIT.BAL.Model;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Interfaces
{
    public interface ISchedule

    {
        ResultModel GetAll(ApplicationUser AppUser);
        ResultModel GetById(int Id, ApplicationUser AppUser);
        ResultModel Insert(ScheduleModel obj, ApplicationUser AppUser);
        ResultModel Update(ScheduleModel obj, ApplicationUser AppUser);
        ResultModel Delete(int Id, ApplicationUser AppUser);
    }
}