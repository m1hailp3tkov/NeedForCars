using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using System.Linq;

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

        public void Add(Car car)
        {
            if (car == null) return;

            this.context.Cars.Add(car);
            this.context.SaveChanges();
        }

        public Car GetById(string id)
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
                    x.BeginningOfProduction == car.BeginningOfProduction &&
                    x.EndOfProduction == car.EndOfProduction);
        }

        public void Update(Car car)
        {
            if (car == null) return;

            this.context.Cars.Update(car);
            this.context.SaveChanges();
        }
    }
}
