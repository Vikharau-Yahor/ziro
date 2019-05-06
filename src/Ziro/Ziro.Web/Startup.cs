using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Ziro.Authentication;
using Ziro.Business.Services;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Persistence;
using Ziro.Persistence.Mappings;
using Ziro.Persistence.Repositories;
using Ziro.Web.Infrastructure;
using Ziro.Web.Infrastructure.Middleware;
using React.AspNet;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.ChakraCore;
using Ziro.Web.Infrastructure.Extensions.Statrup;
using System.Net;
using Ziro.Core.Web.Extensions;
using FluentValidation.AspNetCore;
using System;
using Ziro.Web.Validators;
using Ziro.Web.Validators.Account;
using Ziro.Web.Models.api;
using Newtonsoft.Json;

namespace Ziro.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("system-settings.json");

			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// add configuration
			services.AddOptions();
			services.Configure<SystemSettings>(Configuration);
			services.AddSingleton<ISystemSettings>(x => x.GetService<IOptions<SystemSettings>>().Value);

			//nhibernate
			services.AddSingleton<ISessionFactory>(x =>
			{
				var connectionString = x.GetService<ISystemSettings>().ConnectionString;
				var nhConfiguration = new Configuration().DataBaseIntegration(db =>
				{
					db.ConnectionString = connectionString;
					db.Dialect<MsSql2012Dialect>();
					db.Driver<Sql2008ClientDriver>();
					
				})
				.SetNamingStrategy(new ZiroNamingStrategy());
				var s = new ConventionModelMapper();
				var mapper = new ModelMapper();
				mapper.AddMappings(Assembly.GetAssembly(typeof(UserMap)).GetExportedTypes());
				var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
				nhConfiguration.AddMapping(mapping);
				return nhConfiguration.BuildSessionFactory();
			});
			services.AddScoped<NHibernate.ISession>(x => x.GetService<ISessionFactory>().OpenSession());

			//authentication
			services.AddAuthentication("/Account/Login", "/Account/AccessDenied");

			//react
			services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
				.AddChakraCore();
			services.AddReact();

			//mvc
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>())
				.ConfigureApiBehaviorOptions(options =>
				{
					options.SuppressConsumesConstraintForFormFileParameters = true;
					options.SuppressInferBindingSourcesForParameters = true;
					options.SuppressModelStateInvalidFilter = true;
					options.SuppressMapClientErrors = true;
					options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = false;
				});
			//other services
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ITaskRepository, TaskRepository>();
			services.AddTransient<IProjectRepository, ProjectRepository>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStatusCodePages(async context =>
			{
				var statusCode = context.HttpContext.Response.StatusCode;

				if (context.HttpContext.IsApiRequest())
				{
					string responseContent = null;

					if (statusCode == (int)HttpStatusCode.NotFound)
						responseContent = JsonConvert.SerializeObject(ErrorModel.CreateNotFound());
					else if (statusCode == (int)HttpStatusCode.Unauthorized)
						responseContent = JsonConvert.SerializeObject(ErrorModel.CreateNotAuthenicated());
					else if (statusCode == (int)HttpStatusCode.Forbidden)
						responseContent = JsonConvert.SerializeObject(ErrorModel.CreateForbidden());

					if (responseContent != null)
					{
						context.HttpContext.Response.Clear();
						await context.HttpContext.Response.WriteAsync(responseContent);
					}
				}
			});

			app.UseExceptionHandling(@"/Error/InternalServerError");
			
			app.UseStaticFiles();
			app.UseReact(config =>
			{
				config
					.SetReuseJavaScriptEngines(true)
					.SetLoadBabel(false)
					.SetLoadReact(false)
					.AddScriptWithoutTransform("~/dist/bundle.js")
					.AddScriptWithoutTransform("~/dist/vendor.bundle.js")
					.AddScriptWithoutTransform("~/dist/main.bundle.js");
			});
			app.UseCookiePolicy();

			app.UseMiddleware<DataAccessMiddleware>();
			app.UseAuthentication();
			app.UseMvc(routes =>
			{
				routes.MapRoute("authorize",
					"authorization",
					new { controller = "Home", action = "Index" }
				);

				routes.MapRoute("default",
					"{controller}/{action}/{id?}",
					new { controller = "Home", action = "Index" }
				);
			});
		}
	}
}
