using Microsoft.AspNetCore.Mvc;
using PIT.DBL.Schema;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;

namespace PIT.API.Controllers.common
{
    //   [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlansController : BaseController
    {
        private IPlans _svr ;
        public PlansController(IPlans Service) { _svr = Service; }

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
        public ResultModel Post([FromBody]PlansModel obj)
        {
            return _svr.Insert(obj,AppUser);
        }

        [HttpPut]
        public ResultModel Put([FromBody]PlansModel obj)
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