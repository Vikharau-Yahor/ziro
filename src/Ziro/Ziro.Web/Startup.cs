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
using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.Core.Helpers;
using React.AspNet;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.ChakraCore;

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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			//other services
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserRepository, UserRepository>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseReact(config => { });
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMiddleware<DataAccessMiddleware>();
			app.UseAuthentication();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "areas",
					template: "{area:exists}/{controller=Home}/{action=Index}");

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
