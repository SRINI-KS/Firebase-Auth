using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
namespace SProviderWebApi
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
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
		options.TokenValidationParameters = new TokenValidationParameters
		{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = Configuration["ValidIssuer"],
		ValidAudience = "yourdomain.com",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
		};
		});
			services.Configure<ConnectionSettings>(Configuration.GetSection("ConnectionSettings"));
services.Configure<FormOptions>(x => {
            x.ValueLengthLimit = int.MaxValue;
            x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
			});
			services
			.AddCors()
			.AddMvc()
				.AddNewtonsoftJson(options =>
				{
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
				});
services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "SProvider",
                Description = "SProvider Apis",
 
            });

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
			});
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMiddleware<ErrorLoggingMiddleware>();
app.UseCors(
				options => options.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				
			);
app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			  app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
if(env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SProvider");
                    c.RoutePrefix = "";

                });
            }
            else
            {
                    var basePath = "/SProvider/SProviderWebApi";
                    app.UseSwagger(c =>
                    {
                    c.SerializeAsV2 = true;
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}{basePath}" } };
                    });
                    });
                    app.UseSwaggerUI(c =>
                    {
	                    c.RoutePrefix = "";
	                    c.SwaggerEndpoint("/SProvider/SProviderWebApi/swagger/v1/swagger.json", "SProvider");
                    });
                
            }
		}
	}
}

