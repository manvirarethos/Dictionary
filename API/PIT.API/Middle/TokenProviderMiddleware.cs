using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PIT.API.Models;
using PIT.BAL.Interfaces;
using PIT.BAL.Model;
using PIT.BAL.Services;
using PIT.DBL;
using PIT.DBL.Schema;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PIT.API.Middle
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private IAuth db;


        public TokenProviderMiddleware(IAuth oo,
       RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;

            db = oo;// options.Value.Auth;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("api/") && !context.Request.Path.ToString().Contains("api/login")) // Checking API token
            {
                if (!context.Request.Headers.ContainsKey("Authorization") || !context.Request.Headers.ContainsKey("token"))
                {
                    context.Response.StatusCode = 200;
                    ResultModel oModel = new ResultModel();
                    oModel.Status = 0;
                    oModel.Msg = "Unauthorized access";
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(oModel, new JsonSerializerSettings { Formatting = Formatting.Indented }));

                }
                else
                { return _next(context); }
            }
            else
            { return _next(context); }


        }

     

    }
}
