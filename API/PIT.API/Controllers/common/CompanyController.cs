using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using PIT.DBL.Schema;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;

namespace PIT.API.Controllers.common
{
 //   [Authorize]
    [Produces("application/json")]
    [Route("api/company")]
    public class CompanyController : BaseController
    {
        private ICompany _svr ;
        private IAuth _svrUser ;
       
        public CompanyController(ICompany Service,IAuth ServiceUser) { _svr = Service;_svrUser=ServiceUser; }

        [HttpGet]
        public ResultModel Get()
        {
            
            return _svr.GetAll();
        }
        [HttpGet]
        [Route("{id}")]
        public ResultModel Get(int id)
        {
        
            return _svr.GetById(id);
        }

        [HttpPost]
        public ResultModel Post([FromBody]CompanyModel obj)
        {
             ResultModel oOutput = new ResultModel();
             oOutput= _svr.Insert(obj);
             obj.AppUser.CompanyId = ((CompanyModel)oOutput.Data).ID;
             return _svrUser.Insert(obj.AppUser);
        }

        [HttpPut]
        public ResultModel Put([FromBody]CompanyModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultModel Delete(int ID)
        {
            return _svr.Delete(ID);
        }
    }
}