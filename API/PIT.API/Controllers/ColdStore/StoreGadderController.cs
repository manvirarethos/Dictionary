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
    [Route("api/[controller]")]
    public class StoreGadderController : BaseController
    {
        private IStoreGadder _svr ;
        public StoreGadderController(IStoreGadder Service) { _svr = Service; }

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
        public ResultModel Post([FromBody]StoreGadderModel obj)
        {
            return _svr.Insert(obj);
        }

        [HttpPut]
        public ResultModel Put([FromBody]StoreGadderModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        public ResultModel Delete([FromBody]UnitMasterModel obj)
        {
            return _svr.Delete(obj.ID);
        }
    }
}