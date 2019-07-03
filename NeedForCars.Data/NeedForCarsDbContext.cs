using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeedForCars.Models;

namespace NeedForCars.Data
{
    public class NeedForCarsDbContext : IdentityDbContext<NeedForCarsUser>
    {
        public DbSet<NeedForCarsUser> Users;

        public NeedForCarsDbContext(DbContextOptions<NeedForCarsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
