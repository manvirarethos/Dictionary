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
   // [Authorize]
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private IAuth _svr ;
        public AuthController(IAuth Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {
            
            return _svr.GetAll();
        }

        [HttpPost]
        public ResultModel Post([FromBody]ApplicationUserModel obj)
        {           
          return _svr.Insert(obj);
           // return null;
        }

        [HttpPut]
        public ResultModel Put([FromBody]ApplicationUserModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        public ResultModel Delete([FromBody]ApplicationUserModel obj)
        {
            return _svr.Delete(obj.ID);
        }
        
        [HttpGet]
        [Route("GetUser/{id}")]
        public ResultModel Get(int id )
        {
            return _svr.GetById(id);
         }

    }
}