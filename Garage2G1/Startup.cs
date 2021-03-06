using Garage2G1.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Garage2G1.Models;
using System.Runtime.InteropServices;

namespace Garage2G1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // SQLServer option
            // services.AddDbContext<ParkedVehicleContext>(options => 
            //         options.UseSqlServer(Configuration.GetConnectionString("ParkedVehicleContext")).EnableSensitiveDataLogging());

            // SQLite option
            // services.AddDbContext<ParkedVehicleContext>(options => 
            //         options.UseSqlite(Configuration.GetConnectionString("ParkedVehicleContext")));

            // If running on Windows - use SQLServer, otherwise - use SQLite
            services.AddDbContext<ParkedVehicleContext>(options => {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection"));
                }
                else
                {
                    options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection"));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");
            });
        }
    }
}
