using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.Vehicles;
using Senior_Project.Models.Services;
using Senior_Project.Models.Notifications;

namespace Senior_Project.DataBase
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Filename=./seniorProject.db");
        }
        public DbSet<SystemAdmin> SystemAdmin { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LogTime> LogTimes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<statusOfVehicle> statusOfVehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<onGoingService> onGoingServices { get; set; }
        public DbSet<additionalService> additionalServices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<serviceAssistanceRequest> serviceAssistanceRequests { get; set; }

    }
}
