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
    public class ProductService : IProduct
    {

        private DBL.ApplicationDBContext oDB = null;
        private DbSet<Product> dbSet;

        public ProductService(DBL.ApplicationDBContext _oDB)
        {
            oDB = _oDB;
            dbSet = oDB.Set<Product>();
        }
        public ResultModel Delete(int Id)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                var oReoord = dbSet.Where(m => m.Id == Id).FirstOrDefault();
                if (oReoord == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Sorry, No record exist";
                }
                 else
                {
                    dbSet.Remove(oReoord);
                    oDB.SaveChanges();
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
                oOutput.Data = Mapper.Map<List<ProductModel>>(dbSet.ToList());

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
                oOutput.Data = Mapper.Map<ProductModel>(dbSet.Where(m => m.Id == Id).FirstOrDefault());

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Insert(ProductModel obj)
        {

            ResultModel oOutput = new ResultModel();

            try
            {
                Product oProduct = Mapper.Map<Product>(obj);
                dbSet.Add(oProduct);
                oDB.SaveChanges();
                oOutput.Data = Mapper.Map<ProductModel>(oProduct);

            }
            catch (Exception ex)
            {
                oOutput.Status = 0;
                oOutput.Msg = "Data access error";
                Services.Utitilty.Error(ex);
            }
            return oOutput;
        }

        public ResultModel Update(ProductModel obj)
        {
            ResultModel oOutput = new ResultModel();
            try
            {
               

                Product oProduct = dbSet.Where(m => m.Id == obj.Id).FirstOrDefault();
                if (oProduct == null)
                {
                    oOutput.Status = 0;
                    oOutput.Msg = "Record not exist";
                }
                else
                {
                    // Removing Already Added 
                  
                    Mapper.Map(obj, oProduct);
                    oDB.SaveChanges();
                    oOutput.Data = Mapper.Map<ProductModel>(oProduct);
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
