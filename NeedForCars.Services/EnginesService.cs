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

        public async Task DeleteAsync(Engine engine)
        {
            if (engine == null) return;

            this.context.Engines.Remove(engine);
            await this.context.SaveChangesAsync();
        }

        public Engine GetById(int id)
        {
            return this.context.Engines
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Engine engine)
        {
            if (engine == null) return;

            this.context.Engines.Update(engine);
            await this.context.SaveChangesAsync();
        }

        public void GetRelatedEntitiesCount(Engine engine, out int cars, out int userCars)
        {
            cars = 0;
            userCars = 0;

            if (engine == null) return;

            cars = this.context.Cars
                .Count(x => x.EngineId == engine.Id);

            userCars = this.context.UserCars
                .Count(x => x.Car.EngineId == engine.Id);
        }
    }
}
