using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services
{
    public class CarsService : ICarsService
    {
        private readonly NeedForCarsDbContext context;
        private readonly IGenerationsService generationsService;

        public CarsService(NeedForCarsDbContext context, IGenerationsService generationsService)
        {
            this.context = context;
            this.generationsService = generationsService;
        }

        public async Task AddAsync(Car car)
        {
            if (car == null) return;

            await this.context.Cars.AddAsync(car);
            await this.context.SaveChangesAsync();
        }

        public Car GetById(int id)
        {
            return this.context.Cars
                .Include(x => x.Engine)
                .Include(x => x.Generation)
                    .ThenInclude(x => x.Model)
                        .ThenInclude(x => x.Make)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool Exists(Car car)
        {
            return this.context.Cars
                .Any(x =>
                    x.EngineId == car.EngineId &&
                    x.GenerationId == car.GenerationId &&
                    x.Transmission == car.Transmission &&
                    x.DriveWheel == car.DriveWheel &&
                    x.BeginningOfProductionYear == car.BeginningOfProductionYear &&
                    x.EndOfProductionYear == car.EndOfProductionYear &&
                    x.BeginningOfProductionMonth == car.BeginningOfProductionMonth && 
                    x.EndOfProductionMonth == car.EndOfProductionMonth);
        }

        public async Task UpdateAsync(Car car)
        {
            if (car == null) return;

            this.context.Cars.Update(car);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            if (car == null) return;

            this.context.Remove(car);
            await this.context.SaveChangesAsync();
        }

        public void GetRelatedEntitiesCount(Car car, out int userCars)
        {
            userCars = 0;

            if (car == null) return;

            userCars = this.context.UserCars
                .Count(x => x.CarId == car.Id);
        }

        public IQueryable<Car> GetAllForGeneration(int generationId)
        {
            var cars = this.context.Cars
                .Include(x => x.Engine)
                .Where(x => x.GenerationId == generationId)
                .AsQueryable();

            return cars;
        }
    }
}
