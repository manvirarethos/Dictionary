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
    public class RoleService : IRole
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Role> dbSet;

        public RoleService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Role>();
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
                oOutput.Data = Mapper.Map<List<RoleModel>>(dbSet.Include("Tasks").ToList());

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
                oOutput.Data = Mapper.Map<RoleModel>(dbSet.Include("Tasks").Where(m => m.ID == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(RoleModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Role oUser = Mapper.Map<Role>(obj);
                dbSet.Add(oUser);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<RoleModel>(oUser);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(RoleModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
                // Deleting UnSelected 
                //List<RoleTask> ToDelete = oDB.RoleTask.Where(m => m.RoleID == obj.ID && !obj.Tasks.Where(v => v.ID != 0).Select(x => x.ID).Contains(m.ID)).ToList();
                //oDB.RoleTask.RemoveRange(ToDelete);
                //oDB.SaveChanges();


                Role oUser = dbSet.Include("Tasks").Where(m => m.ID == obj.ID).FirstOrDefault();
                if (oUser == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                    obj.Tasks.ForEach(m => m.ID = 0);
                    Mapper.Map(obj, oUser);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<RoleModel>(oUser);
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
