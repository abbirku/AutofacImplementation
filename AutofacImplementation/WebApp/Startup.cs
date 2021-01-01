using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            //For appsettings enviroment variables (needed for Autofac)
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        //Needed for Autofac
        public static ILifetimeScope AutofacContainer { get; private set; }

        //Note in future we will pass connectionString & migrationAssemblyName for dbContext
        //Ex:
        /**
         *  var connectionStringName = "DefaultConnection";
         *  var connectionString = Configuration.GetConnectionString(connectionStringName);
         *  var migrationAssemblyName = typeof(Startup).Assembly.FullName;
         *  builder.RegisterModule(new InfrastructureModule(connectionString, migrationAssemblyName));
         * **/

        //Needed for Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var minVal = Configuration.GetValue(typeof (int), "Offers:minVal");
            var maxVal = Configuration.GetValue(typeof(int), "Offers:maxVal");

            builder.RegisterModule(new InfrastructureModule((int)minVal, (int)maxVal));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Needed for Autofac
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
