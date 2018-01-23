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
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private IUser _svr ;
       
        public UserController(IUser Service) { _svr = Service; }



        [HttpPost]
        public ResultModel Post([FromBody]UserModel obj)
        {
            return _svr.Insert(obj);
          // return null;
        }

       
    }
}