using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task AddAsync(Engine engine)
        {
            if (engine == null) return;

            await this.context.Engines.AddAsync(engine);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string engineId)
        {
            var engine = this.GetById(engineId);
            if (engine == null) return;

            this.context.Engines.Remove(engine);
            await this.context.SaveChangesAsync();
        }

        public Engine GetById(string id)
        {
            return this.context.Engines
                .Include(x => x.Cars)
                .Include(x => x.ModifiedCars)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Engine engine)
        {
            if (engine == null) return;

            this.context.Engines.Update(engine);
            await this.context.SaveChangesAsync();
        }
    }
}
