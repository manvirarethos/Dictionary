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
using PIT.BAL.Interfaces.Dictonary;
using PIT.BAL.Model;

namespace PIT.API.Controllers.Dictonary
{
    // [Authorize]
    [Produces("application/json")]
   [Route("api/[controller]")]
    public class SourceController : BaseController
    {
        private ISource _svr;
        public SourceController(ISource Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {

            return _svr.GetAll();
        }
       [HttpGet]
         [Route("active")]
        public ResultModel GetActive()
        {

            return _svr.GetActive();
        }

        [HttpPost]
        public ResultModel Post([FromBody]SourceModel obj)
        {
            return _svr.Insert(obj);
        }

        [HttpPut]
        public ResultModel Put([FromBody]SourceModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
         [Route("{id}")]
        public ResultModel Delete(int id)
        {
            return _svr.Delete(id);
        }
    }
}