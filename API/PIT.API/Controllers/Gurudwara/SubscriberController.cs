using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;
using PIT.DBL.Schema;


namespace PIT.API.Controllers.common {
    //   [Authorize]
    [Produces ("application/json")]
    [Route ("api/subscriber")]
    public class SubscriberController : BaseController {
        private ISubscriber _svr;

        public SubscriberController (ISubscriber Service) { _svr = Service; }

        [HttpPost]
        [Route("Register")]
        public ResultModel Register ([FromBody] subscriberModel obj) {
                return _svr.Register (obj);
            }

 [HttpPost]
        [Route("ResendCode")]
        public ResultModel ResendCode ([FromBody] subscriberModel obj) {
                return _svr.ResendCode (obj);
            }


  [HttpPost]
  [Route("VerifyCode")]
        public ResultModel VerifyCode ([FromBody] subscriberModel obj) {
                return _svr.VerifyCode(obj,AppUser==null?0:AppUser.CompanyID);
            }

            [HttpGet]
        public ResultModel Get () {
            return (new ResultModel ());
        }
    }
}