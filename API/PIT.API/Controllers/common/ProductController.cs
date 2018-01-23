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
    [Route("api/product")]
    public class ProductController : BaseController
    {
        private IProduct _svr;
        private IAuth _svrUser;

        public ProductController(IProduct Service, IAuth ServiceUser) { _svr = Service; _svrUser = ServiceUser; }

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
        public ResultModel Post([FromBody]ProductModel obj)
        {
            ResultModel oOutput = new ResultModel();
            return oOutput = _svr.Insert(obj);
            //obj.AppUser.CompanyId = ((ProductModel)oOutput.Data).ID;
            //return _svrUser.Insert(obj.AppUser);
        }

        [HttpPut]
        public ResultModel Put([FromBody]ProductModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultModel Delete(int ID)
        {
            return _svr.Delete(ID);
        }
    }
}