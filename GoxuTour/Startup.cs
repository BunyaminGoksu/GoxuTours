using GoxuTour.Application.Buses;
using GoxuTour.Application.BusManufacturers;
using GoxuTour.Application.BusModels;
using GoxuTour.Application.Cities;
using GoxuTour.Application.Repositories;
using GoxuTour.Application.Stations;
using GoxuTour.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoxuTour
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
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<IStationService, StationService>();
            services.AddTransient<IStationRepository, StationRepository>();

            services.AddTransient<IBusManufacturerService, BusManufacturerService>();
            services.AddTransient<IBusManufacturerRepository, BusManufacturerRepository>();

            services.AddTransient<IBusModelService, BusModelService>();
            services.AddTransient<IBusModelRepository, BusModelRepository>();

            services.AddTransient<IBusService, BusService>();
            services.AddTransient<IBusRepository, BusRepository>();

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
