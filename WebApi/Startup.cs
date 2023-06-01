using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using System.IO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces.Configurations;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.WebApi.Controllers;
using VG.CDF.Server.WebApi.DataBaseContext;

namespace VG.CDF.Server.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            MapperConfiguration mapperConfig;

            #region MapperConfiguration
            mapperConfig = new MapperConfiguration(cfg => cfg.
                AddMaps(new Assembly[]
                {
                    //Assembly.GetAssembly(typeof(SourceMappingProfiler)),
                    //Assembly.GetAssembly(typeof(TagReportTaskMappingProfiler))
                }));
            services.AddSingleton(s => mapperConfig.CreateMapper());
            #endregion
            services.AddSingleton<IDbConnectionConfig>(Configuration.GetSection("DbConnectionConfig").Get<DbConnectionConfig>());
            services.AddSingleton(Configuration.GetSection("DbConnectionConfig").Get<DbConnectionConfig>());
            services.AddSingleton(Configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>());
            services.RegistrateServices(Configuration);
            services.RegistrateValidators();
            
            var connectionString = Configuration["DbConnectionConfig:ConnectionString"];
            services.AddDbContext<SqlDataContext>(
                opts => opts.UseNpgsql("Host=localhost;Port=5432;Database=volgor_asud;Username=postgres;Password=sa;")
            );

            //services.AddDbContext<SqlDataContext>();
            services.AddScoped(sp =>
            new HttpClient()
            {
                BaseAddress = new Uri(@"http://localhost:5000"),
                                
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddAuthenticationCore();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfiguration:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfiguration:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["JwtConfiguration:Key"]))
                };
            });

            services.AddMvc();
            services.AddRazorPages();

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(Startup).Assembly);
            services
               .AddProblemDetails(ConfigureProblemDetails)
               .AddSwaggerGen(ConfigureSwaggerGenOptions)
               .ConfigureSwaggerGen(options =>
               {
                   options
                       .IncludeXmlFile(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            DbConnectionConfig dbConnectionConfig)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //app.UseCors(builder =>
            //   builder.WithOrigins()
            //       .AllowAnyOrigin()
            //       .AllowAnyHeader()
            //       .AllowAnyMethod());

            app.UseCors("Open");
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json",
                       $"{Assembly.GetExecutingAssembly().GetName().Name}");
               })
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                }).UseProblemDetails();

            //app.UseStaticFiles();

            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapBlazorHub();
            //    endpoints.MapFallbackToPage("/_Host");
            //});
        }

        private void ConfigureProblemDetails(ProblemDetailsOptions options)
        {

            options.OnBeforeWriteDetails = (ctx, problem) =>
            {
                problem.Extensions["traceId"] = ctx.TraceIdentifier;
                problem.Extensions["problem"] = problem.Detail;
            };
            options.MapToStatusCode<ValidationException>(StatusCodes.Status400BadRequest);
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);

        }
        private void ConfigureSwaggerGenOptions(SwaggerGenOptions options)
        {
            var ver = GetType()!.Assembly!.GetName()!.Version!.ToString();
            options.SwaggerDoc("v1", new OpenApiInfo { Title = $"{Assembly.GetExecutingAssembly().GetName().Name}", Version = ver });
            options.DocumentFilter<SwaggerAddEnumDescriptions>();
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

        }
    }
}
