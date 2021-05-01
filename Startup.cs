using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.INotifications;
using Senior_Project.IRepository.IServices;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Repositories.Accounts;
using Senior_Project.Repositories.Notifications;
using Senior_Project.Repositories.Services;
using Senior_Project.Repositories.Vehicles;
using Senior_Project.Controllers.hubController;
using Microsoft.Extensions.Options;
using Senior_Project.Controllers.serviceController;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Senior_Project.Handlers.accountHandler;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Senior_Project
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
            var key = "this the my key for the project";

            services.AddSingleton<IAuthenticate>(new Authenticate(key));

            services.AddDbContext<AppDbContext>();
            services.AddScoped<ICustomerRepository, customerRepository>();
            services.AddScoped<IVehicleRepository, vehicleRepository>();
            services.AddScoped<IStatOfVehicleRepository, statOfVehicleRepository>();
            services.AddScoped<IServiceRepository, serviceRepository>();
            services.AddScoped<IOnGoingServRepository, onGoingServRepository>();
            services.AddScoped<IAddServRepository, addServRepository>();
            services.AddScoped<IServAssReqRepository, servAssReqRepository>();
            services.AddScoped<INotificationRepository, notificationRepository>();
            services.AddScoped<IApplicationRepository, applicationRepository>();
            services.AddScoped<ILogtimeRepository, logTimeRepository>();
            services.AddScoped<ILocationRepository, locationRepository>();
            services.AddScoped<ISysAdminRepository, sysAdminRepository>();
            services.AddScoped<IGarageRepository, garageRepository>();
            services.AddScoped<IMechanicRepository, mechanicRepository>();
            services.AddControllers();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSignalR();
            services.AddCors(Options =>
            {
                Options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000",
                                 "http://localhost:3001",
                                 "http://localhost:3002",
                                 "http://localhost:3004")
                    .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("ClientPermission");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<notificationHub>("/controllers/hubcontrollers/notification");
            });
        }
    }
}
