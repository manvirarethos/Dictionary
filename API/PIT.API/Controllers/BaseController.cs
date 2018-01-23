using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PIT.BAL.Model;
using Newtonsoft.Json;
using PIT.DBL.Schema;

namespace PIT.API.Controllers
{

    public class BaseController : Controller
    {
        public ApplicationUser AppUser
        {
            get { return GetCurrentUser(); }
        }

        private ApplicationUser GetCurrentUser()
        {
            var base64EncodedBytes = System.Convert.FromBase64String(Request.Headers["token"].ToString());
            var jsonString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            ApplicationUser Data = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);
            return Data;
        }

        public MobileDeviceModel DeviceInfo
        {
            get { return GetCurrentMobileDevice(); }

        }

        private MobileDeviceModel GetCurrentMobileDevice()
        {
            var base64EncodedBytes = System.Convert.FromBase64String(Request.Headers["devicetoken"].ToString());
            var jsonString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            MobileDeviceModel Data = JsonConvert.DeserializeObject<MobileDeviceModel>(jsonString);
            return Data;
        }
    }
}
