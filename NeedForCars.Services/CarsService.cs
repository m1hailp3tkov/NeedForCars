using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;

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
    }
}
