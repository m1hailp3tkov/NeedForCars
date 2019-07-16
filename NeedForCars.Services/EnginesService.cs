using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using System.Linq;

namespace NeedForCars.Services
{
    public class EnginesService : IEnginesService
    {
        private readonly NeedForCarsDbContext context;

        public EnginesService(NeedForCarsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Engine> All()
        {
            return this.context.Engines;
        }

        public void Add(Engine engine)
        {
            if (engine == null) return;

            this.context.Engines.Add(engine);
            this.context.SaveChanges();
        }

        public void Delete(string engineId)
        {
            var engine = this.GetById(engineId);
            if (engine == null) return;

            this.context.Engines.Remove(engine);
            this.context.SaveChanges();
        }

        public Engine GetById(string id)
        {
            return this.context.Engines
                .Include(x => x.Cars)
                .Include(x => x.ModifiedCars)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Engine engine)
        {
            if (engine == null) return;

            this.context.Engines.Update(engine);
            this.context.SaveChanges();
        }
    }
}
