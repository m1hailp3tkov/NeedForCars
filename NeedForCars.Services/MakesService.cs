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

        public bool Exists(string makeName)
        {
            return this.context.Makes
                .Any(x => x.Name == makeName);
        }

        public IQueryable<Make> GetAll()
        {
            return this.context.Makes;
        }

        public Make GetById(string id)
        {
            return this.context
                .Makes
                .Include(x => x.Models)
                .FirstOrDefault(x => x.Id == id || x.Name == id);
        }

        public void Update(Make make)
        {
            this.context.Makes
                .Update(make);

            this.context.SaveChanges();
        }
    }
}
