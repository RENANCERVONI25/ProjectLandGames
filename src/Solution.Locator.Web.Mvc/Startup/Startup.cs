using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Solution.Locator.Authentication.JwtBearer;
using Solution.Locator.Configuration;
using Solution.Locator.Identity;
using Solution.Locator.Web.Resources;
using Microsoft.AspNetCore.Http;
using Solution.Locator.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#if FEATURE_SIGNALR
using Owin;
using Abp.Owin;
using Solution.Locator.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif

namespace Solution.Locator.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

          
            services.AddDbContext<LocatorDbContext>(options =>
                                                        options.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB; Database=LocatorDb; Trusted_Connection=True;MultipleActiveResultSets=true;"));

            services.AddScoped<IWebResourceManager, WebResourceManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif

            // Configure Abp and Dependency Injection
            return services.AddAbp<LocatorWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "Locator";

            app.UseAbp();

            app.MapSignalR();
        }
#endif
    }
}
