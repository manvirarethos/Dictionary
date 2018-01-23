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
    //  [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private IMenuTask _svr;
        public TaskController(IMenuTask Service) { _svr = Service; }

        [HttpGet]
        [Route("GetTask/{id}")]
        public ResultModel Get(int id )
        {
          
                return _svr.GetById(id);

        }

        [HttpGet]
        public ResultModel Get()
        {
           
                return _svr.GetAll();
          

        }
        [HttpPost]
        public ResultModel Post([FromBody]MenuTaskModel obj)
        {
            return _svr.Insert(obj);
        }

        [HttpPut]
        public ResultModel Put([FromBody]MenuTaskModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        public ResultModel Delete(int id)
        {
            return _svr.Delete(id);
        }
    }
}