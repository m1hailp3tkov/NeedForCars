using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NeedForCars.Services
{
    public class MakesService : IMakesService
    {
        private readonly NeedForCarsDbContext context;

        public MakesService(NeedForCarsDbContext context)
        {
            this.context = context;
        }

        public void Add(Make make)
        {
            if (make == null) return;

            this.context.Makes.Add(make);
            this.context.SaveChanges();
        }

        public bool Exists(Make make)
        {
            return this.context.Makes
                .Any(x => x.Name == make.Name);
        }

        public ICollection<Make> GetAll()
        {
            return this.context.Makes.ToList();
        }
    }
}
