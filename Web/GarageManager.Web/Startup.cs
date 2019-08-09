using AutoMapper;
using GarageManager.Data;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Extensions.Email;
using GarageManager.Extensions.PDFConverter.HtmlToPDF;
using GarageManager.Extensions.PDFConverter.ViewRender;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using GarageManager.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GarageManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var result = this.Configuration.GetSection("SendGridApiKey");
            services.Configure<SendGridOptions>(this.Configuration.GetSection("SendGride"));
          

            services
                .AddDbContext<GMDbContext>(options =>
                options
                .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Transient);


            services.AddIdentity<GMUser, IdentityRole>(/*config =>
            config.SignIn.RequireConfirmedEmail = true*/)
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GMDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
            });

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                    options.Filters.Add<LogExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddTransient(typeof(IDeletableEntityRepository<>), typeof(DeletableEntityRepository<>));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IHtmlToPdfConverter, HtmlToPdfConverter>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IInterventionService, InterventionService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<ITransmissionTypesService, TransimissionTypesService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IRepairService, RepairService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();



             services
               .AddAutoMapper(typeof(Startup)); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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


            loggerFactory.AddSerilog();
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
