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
        public DbSet<NeedForCarsUser> Users { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Message> Messages { get; set; }


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

            // Cars
            builder.Entity<NeedForCarsUser>()
                .HasMany(x => x.Cars)
                .WithOne(x => x.Owner);


            // Messages
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


            //ModelEngines
            builder.Entity<ModelEngines>()
                .HasKey(x => new { x.EngineId, x.ModelId });

            builder.Entity<ModelEngines>()
                .HasOne(x => x.Model)
                .WithMany(x => x.ModelEngines)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ModelEngines>()
                .HasOne(x => x.Engine)
                .WithMany(x => x.ModelEngines)
                .HasForeignKey(x => x.EngineId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
