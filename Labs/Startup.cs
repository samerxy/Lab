using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using JwtAuth;
using Labs.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore.Design;

namespace Labs
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //database
            services.AddDbContext<LabsContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            services.AddScoped<FilterAPI>();
            services.AddJwtAuth(c =>
            {
                c.HashKey = Encoding.UTF8.GetBytes(Configuration.GetSection("keys:hashKey").Value);
                //c.CryptoKey = Encoding.UTF8.GetBytes(Configuration.GetSection("keys:hashKey").Value);
                c.ExpirationTime = TimeSpan.FromDays(365);
                List<string> lss = new List<string>();
                lss.Add("ADMIN");
                c.GetUserRolesAsyncFunc = async (object userID, HttpContext context) => await Task.FromResult(lss);
                c.GetUserPolicesAsyncFunc = (object userID, HttpContext context) => null;
                c.VerifyUserAsyncFunc =
                    async (object userID, DateTime iat, DateTime exp, string token, Dictionary<string, object> meta) =>
                        await Task.FromResult(true);
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly))
                .AddXmlSerializerFormatters();
                

            services.Configure<ApiBehaviorOptions>(c => c.SuppressModelStateInvalidFilter = true);
            services.AddHttpClient();


            services.AddSignalR(e => e.EnableDetailedErrors = true);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
