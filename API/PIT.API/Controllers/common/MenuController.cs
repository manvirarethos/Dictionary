using Microsoft.AspNetCore.Mvc;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;

namespace PIT.API.Controllers.common
{
    // [Authorize]
    [Produces("application/json")]
    [Route("api/menu")]
    public class MenuController : BaseController
    {
        private IMenu _svr;
        public MenuController(IMenu Service) { _svr = Service; }

        [HttpGet]
        public ResultModel Get()
        {

            return _svr.GetAll();
        }

        [HttpPost]
        public ResultModel Post([FromBody]MenuModel obj)
        {
            return _svr.Insert(obj);
        }

        [HttpPut]
        public ResultModel Put([FromBody]MenuModel obj)
        {
            return _svr.Update(obj);
        }

        [HttpDelete]
        public ResultModel Delete([FromBody]MenuModel obj)
        {
            return _svr.Delete(obj.ID);
        }
    }
}