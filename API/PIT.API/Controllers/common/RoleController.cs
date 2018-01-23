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
    [Route("api/role")]
    public class RoleController : BaseController
    {
        private IRole _svr ;
        public RoleController(IRole Service) { _svr = Service; }

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
        public ResultModel Post([FromBody]RoleModel obj)
        {
            return _svr.Insert(obj);
        }

        [HttpPut]
        public ResultModel Put([FromBody]RoleModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        public ResultModel Delete([FromBody]RoleModel obj)
        {
            return _svr.Delete(obj.ID);
        }
    }
}