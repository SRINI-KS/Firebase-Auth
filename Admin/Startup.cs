using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using  Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;
namespace Admin
{
		public class Startup
		{
			public Startup(IConfiguration configuration, IWebHostEnvironment env, IServiceProvider serviceProvider)
			{
				Configuration = configuration;
				var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
				//var mvcBuilder = serviceProvider.GetService<IMvcBuilder>();
				//new MvcConfiguration().ConfigureMvc(mvcBuilder);
				Configuration = builder.Build();
		}
			public IConfiguration Configuration { get; }
			public void ConfigureServices(IServiceCollection services)
			{
//Please remove comment from below line if you wish to see the changes of razor files immediately
//services.AddRazorPages().AddRazorRuntimeCompilation();
				services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
				services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
				services.Configure<FormOptions>(options => { options.ValueCountLimit = int.MaxValue; options.ValueLengthLimit = int.MaxValue; options.MultipartBodyLengthLimit = int.MaxValue; });

				services.AddDistributedMemoryCache();
				services.AddSession(options =>
				{
					options.IdleTimeout = TimeSpan.FromMinutes(60);
				});
				services.Configure<IISOptions>(options =>
				{
				});
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc().AddFluentValidation()
				.AddNewtonsoftJson(options =>
				{
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
				});
		}
			public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
				app.UseStaticFiles();
				if (env.IsDevelopment())
				{
					app.UseDeveloperExceptionPage();
				}
				else
				{
					app.UseExceptionHandler("/Home/Error");
				}
				app.UseSession();
			app.UseMiddleware<ErrorLoggingMiddleware>();
if (env.IsProduction())
{
app.Use((context, next) =>
{
context.Request.PathBase = Configuration.GetValue<string>("envSettings:basePath");
return next();
});
}
			app.Use(async (context, next) =>
				{
					context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
					context.Response.Headers.Add("X-Xss-Protection", "1");
					context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
					await next();
				});
			app.UseForwardedHeaders(new ForwardedHeadersOptions
				{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor |
				ForwardedHeaders.XForwardedProto
				});
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute("area", "{area:exists}/{controller=users}/{action=Login}/{id?}");
endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=users}/{action=Login}/{id?}");
});
			}
		}
}

