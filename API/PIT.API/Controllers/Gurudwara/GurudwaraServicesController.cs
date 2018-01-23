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
    [Route("api/gurudwaraservices")]
    public class GurudwaraServicesController : BaseController
    {
        private IGurudwaraServices _svr;
        public GurudwaraServicesController(IGurudwaraServices Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {
            return _svr.GetAll(AppUser);
        }

        [HttpPost]
        public ResultModel Post([FromBody]GurudwaraServicesModel obj)
        {
            return _svr.Insert(obj,AppUser);
        }
    }
}