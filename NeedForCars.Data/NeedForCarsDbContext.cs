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
        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Generation> Generations { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<NeedForCarsUser> Users { get; set; }

        public DbSet<UserCar> UserCars { get; set; }



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

            // User
            // --Cars
            builder.Entity<NeedForCarsUser>()
                .HasMany(x => x.UserCars)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId);

            builder.Entity<UserCar>()
                .OwnsOne(x => x.ModifiedFuelConsumption);

            builder.Entity<UserCar>()
                .OwnsOne(x => x.ModifiedAcceleration);

            // --Messages
            builder.Entity<NeedForCarsUser>()
                .HasMany(x => x.SentMessages)
                .WithOne(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<NeedForCarsUser>()
                .HasMany(x => x.ReceivedMessages)
                .WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);


            // Cars
            builder.Entity<Car>()
                .OwnsOne(x => x.FuelConsumption);

            builder.Entity<Car>()
                .OwnsOne(x => x.Acceleration);
        }
    }
}
