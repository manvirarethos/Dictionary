using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;
using PIT.DBL.Schema;

namespace PIT.BAL.Services.Gurudwara {
    public class SubscriberService : ISubscriber {
        private DBL.ApplicationDBContext oDB = null;
        private DbSet<subscriber> dbSet;
        private ICommunication _svr;
        public SubscriberService (DBL.ApplicationDBContext _oDB, ICommunication Service) {
            _svr = Service;
            oDB = _oDB;
            dbSet = oDB.Set<subscriber> ();
        }

        public ResultModel ResendCode (subscriberModel obj) {
            ResultModel oOutput = new ResultModel ();
            try {
                Utitilty oUtility = new Utitilty ();
                obj.VerificationCode = oUtility.GetVerificationCode (3);

                var oSubscriberDetail = dbSet.Where (m => m.EmailAddress == obj.EmailAddress && m.GurudwaraCode == obj.GurudwaraCode).FirstOrDefault ();
                if (oSubscriberDetail != null) {
                    oSubscriberDetail.VerificationCode = obj.VerificationCode;
                    oSubscriberDetail.IsVerified = false;
                    oDB.SaveChanges ();
                }

                #region Send Email Communication

                CommunicationModel oModel = new CommunicationModel ();
                oModel.AlertTypeID = 1;
                oModel.Contents = "Your Verification Code is " + obj.VerificationCode;
                oModel.Subject = "Verication Code";
                oModel.SentTo = obj.EmailAddress;
                oModel.WhenToSend = DateTime.Now;
                oModel.CreatedDate = DateTime.Now;
                _svr.SendCommunication (oModel);
                #endregion

            } catch (Exception ex) {

            }
            return oOutput;
        }

        public ResultModel VerifyCode (subscriberModel obj, int CompanyId) {
            ResultModel oOutput = new ResultModel ();
            try {
                var oSubscriberDetail = dbSet.Where (m => m.EmailAddress == obj.EmailAddress && m.GurudwaraCode == obj.GurudwaraCode && m.VerificationCode == obj.VerificationCode).FirstOrDefault ();
                if (oSubscriberDetail != null) {
                    oSubscriberDetail.IsVerified = true;
                    oSubscriberDetail.VerificationCode = null;
                    oDB.SaveChanges ();

                    subscribergurudwara osubscribergdwara = new subscribergurudwara ();
                    osubscribergdwara.GurudwaraID = 4;
                    osubscribergdwara.SubscriberID = oSubscriberDetail.ID;
                    osubscribergdwara.IsActive = true;
                    oDB.SubscriberGurudwara.Add (osubscribergdwara);
                    oDB.SaveChanges ();
                }

            } catch (Exception ex) {

            }
            return oOutput;
        }

        public ResultModel Register (subscriberModel obj) {
            ResultModel oOutput = new ResultModel ();
            try {
                Utitilty oUtility = new Utitilty ();
                obj.VerificationCode = oUtility.GetVerificationCode (3);
                var oSubscriber = dbSet.Where (m => m.EmailAddress == obj.EmailAddress && m.GurudwaraCode == obj.GurudwaraCode).FirstOrDefault ();

                subscriber osubscriber = Mapper.Map<subscriber> (obj);
                if (oSubscriber == null) {
                    dbSet.Add (osubscriber);
                    oDB.SaveChanges ();
                }

                #region Send Email Communication

                CommunicationModel oModel = new CommunicationModel ();
                oModel.AlertTypeID = 1;
                oModel.Contents = "Your Verification Code is " + obj.VerificationCode;
                oModel.Subject = "Verication Code";
                oModel.SentTo = obj.EmailAddress;
                oModel.WhenToSend = DateTime.Now;
                oModel.CreatedDate = DateTime.Now;
                _svr.SendCommunication (oModel);
                #endregion

                oOutput.Data = Mapper.Map<subscriberModel> (osubscriber);
            } catch (Exception ex) {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error (ex);
            }
            return oOutput;

        }

        public ResultModel Verification (subscriberModel obj) {
            ResultModel oOutput = new ResultModel ();
            try {

            } catch (Exception ex) {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error (ex);
            }
            return oOutput;

        }

    }
}