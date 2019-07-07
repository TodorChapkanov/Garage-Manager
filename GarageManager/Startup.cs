﻿using AutoMapper;
using GM.DAL;
using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using GM.Services;
using GM.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GarageManager
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddDbContext<GMDbContext>(options =>
                options
                .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);


            services.AddIdentity<GMUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GMDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IManufacturerServices, ManufacturerServices>();
            services.AddScoped<IModelRepositoty, ModelRepository>();
            services.AddScoped<IModelServices, ModelServices>();
            services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
            services.AddScoped<IFuelTypeServices, FuelTypeServices>();
            services.AddScoped<ITransmissionTypeRepository, TransmissionTypeRepository>();
            services.AddScoped<ITransmissionTypeServices, TransimissionTypeServices>();



             services
               .AddAutoMapper(typeof(Startup)); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                         name: "areaRoute",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
