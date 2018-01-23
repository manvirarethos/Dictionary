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
    [Route("api/activity")]
    public class ActivityController : BaseController
    {
        private IActivity _svr;
        public ActivityController(IActivity Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {
            return _svr.GetAll(AppUser);
        }
        [HttpGet]
        [Route("{id}")]
        public ResultModel Get(int id)
        {
            return _svr.GetById(id,AppUser);
        }

        [HttpPost]
        public ResultModel Post([FromBody]ActivityModel obj)
        {
            obj.CompanyId = AppUser.CompanyID;
            return _svr.Insert(obj,AppUser);
        }

        [HttpPut]
        public ResultModel Put([FromBody]ActivityModel obj)
        {
            return _svr.Update(obj,AppUser);
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultModel Delete(int id)
        {
            return _svr.Delete(id,AppUser);
        }
    }
}