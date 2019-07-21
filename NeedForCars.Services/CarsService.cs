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

        public CarsService(NeedForCarsDbContext context)
        {
            this.context = context;
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

        public bool Exists(Car car, string generationName)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Car car)
        {
            if (car == null) return;

            this.context.Cars.Update(car);
            this.context.SaveChanges();
        }
    }
}
