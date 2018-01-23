using Microsoft.IdentityModel.Tokens;
using PIT.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.API.Models
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/login";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);
        public SigningCredentials SigningCredentials { get; set; }

        public IAuth Auth  { get; set; }

      
    }
}
