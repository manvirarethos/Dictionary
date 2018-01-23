using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PIT.DBL;
using PIT.API.Models;
using PIT.API.Middle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PIT.BAL.Utility;
using Microsoft.AspNetCore.Identity;

namespace PIT.API
{
    public class Startup
    {
        private static readonly string secretKey = "amriksinghsatwinderpalsinghcandaindia";
        private static readonly string issure = "PIXUser";
        private static readonly string audience = "PIXAudience";
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");

            services.AddCors();
            // Service Class AutoMapper and  Dependency Injection
            AutoMapper.Mapper.Initialize(cong => cong.AddProfile<AutomapperProfile>());
            BAL.Utility.Dependency.AddToDependency(services);

            services.AddDbContext<PIT.DBL.ApplicationDBContext>(options =>
            options.UseMySql(sqlConnectionString, b => b.MigrationsAssembly("PIT.DBL")));
            services.AddScoped(p => new PIT.DBL.ApplicationDBContext(p.GetService<DbContextOptions<ApplicationDBContext>>()));
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
                   {

                       options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,

                                ValidIssuer = issure,
                                ValidAudience = audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                            };
                   });


            services.AddMvc();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
            //resolve implementations
            //  var dbContext = serviceProvider.GetService<CommunicatorContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
            app.UseCors(b => b.WithOrigins("*","http://localhost:4200","http://8.38.88.31:82").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            var fooService = service.GetService<BAL.Interfaces.IAuth>();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var jwtOptions = new TokenProviderOptions
            {
                Auth = fooService,
                Audience = audience,
                Issuer = issure,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
            //  app.UseMiddleware<TokenProviderMiddleware>(Microsoft.Extensions.Options.Options.Create(jwtOptions));


            app.UseAuthentication();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(builder =>
            //                     builder.AllowAnyOrigin().AllowAnyHeader()
            //                     );
            app.UseMvc();
        }
    }
}
