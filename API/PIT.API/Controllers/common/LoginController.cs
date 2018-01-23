using System;
using System.Collections.Generic;
 using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PIT.DBL.Schema;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;
using Microsoft.Extensions.Options;
using PIT.API.Models;

namespace PIT.API.Controllers.common
{

    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : BaseController
    {
        private IAuth _svr;
        private readonly TokenProviderOptions _options;

        public LoginController(IAuth Service, IOptions<TokenProviderOptions> options)
        {
            _svr = Service; _options = options.Value;
        }

        [HttpPost]
        public ResultModel Post([FromBody]LoginModel obj)
        {
            return GenerateToken(obj);
        }

        private ResultModel GenerateToken(LoginModel context)
        {
            ResultModel oModel = new ResultModel();
            try
            {
                var identity = _svr.VerifyUser(new LoginModel() { Password = context.Password, UserName = context.UserName });
                // PIT.BAL.Model.ResultModel oUserModel = identity;
                if (identity.Status == 0)
                {
                    oModel.Status = 0;
                    oModel.Msg = "Username/password invalid";
                    return oModel;
                }
                var now = DateTime.UtcNow;

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(JwtRegisteredClaimNames.NameId, ((ApplicationUser)identity.Data).ID.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, context.UserName));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()));

                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration),
                    signingCredentials: _options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    user = identity.Data,
                    access_token = encodedJwt,
                    expires_in = (int)_options.Expiration.TotalSeconds
                };
                oModel.Data = response;
            }
            catch (Exception ex)
            {
                oModel.Status = 0;
                oModel.Msg = "Invalid User";
                BAL.Services.Utitilty.Error(ex);
                //  await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Message, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            }
            return oModel;
        }
    }
}