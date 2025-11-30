using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarRentalManagement.Data;
using CarRentalManagement.Configurations.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalManagement.Data
{
    public class CarRentalManagementContext : IdentityDbContext<CarRentalManagementUser>
    {
        public CarRentalManagementContext (DbContextOptions<CarRentalManagementContext> options)
            : base(options)
        {
        }
            public DbSet<CarRentalManagement.Domain.Make> Make { get; set; } = default!;
            public DbSet<CarRentalManagement.Domain.Model> Models { get; set; } = default!;
            public DbSet<CarRentalManagement.Domain.Colour> Colour { get; set; } = default!;
        public DbSet<CarRentalManagement.Domain.Vehicle> Vehicle { get; set; } = default!;
            public DbSet<CarRentalManagement.Domain.Booking> Booking { get; set; } = default!;
            public DbSet<CarRentalManagement.Domain.Customer> Customer { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ColourSeed());
        }
    }
}
