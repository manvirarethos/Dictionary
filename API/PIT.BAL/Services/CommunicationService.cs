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
    public class CommunicationService : ICommunication
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<communication> dbSet;

        public CommunicationService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<communication>();
        }

        public ResultModel SendCommunication(CommunicationModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
               // SendEmail(obj.SentTo,obj.Subject, obj.Contents);
                SaveCommunication(obj);
            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

         public static bool SendEmail(string emailto, string subject, string body)
        {
            try
            {
                bool returndata = false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveCommunication(CommunicationModel obj)
        {
            try
            {
                communication oComm = new communication();
                oComm.SentTo = obj.SentTo;
                oComm.WhenToSend = obj.WhenToSend;
                oComm.SentTime = DateTime.Now;
                oComm.Subject = obj.Subject;
                oComm.AlertTypeID = 1;
                oComm.CommunicationStatusID=3;
                oComm.Contents = obj.Contents;
                oComm.CreatedDate=DateTime.Now;
                oDB.Communication.Add(oComm);
                oDB.SaveChanges();
                oDB.Dispose();
                oDB = null;
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }

    }
}
