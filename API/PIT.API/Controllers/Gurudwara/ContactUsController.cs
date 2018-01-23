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
    [Route("api/contactus")]
    public class ContactUsController : BaseController
    {
        private IContactUs _svr;
        public ContactUsController(IContactUs Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {
            return _svr.GetAll(AppUser);
        }

        [HttpPost]
        public ResultModel Post([FromBody]ContactUsModel obj)
        {
            return _svr.Insert(obj,AppUser);
        }
    }
}