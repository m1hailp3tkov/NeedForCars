using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services
{
    public class MakesService : IMakesService
    {
        private readonly NeedForCarsDbContext context;

        public MakesService(NeedForCarsDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Make make)
        {
            if (make == null) return;

            await this.context.Makes.AddAsync(make);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Make make)
        {
            if (make == null) return;

            this.context.Makes.Remove(make);
            await this.context.SaveChangesAsync();
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

        public Make GetById(int id)
        {
            return this.context
                .Makes
                .Include(x => x.Models)
                .FirstOrDefault(x => x.Id == id);
        }

        public void GetRelatedEntitiesCount(Make make, out int models, out int generations, out int cars, out int userCars)
        {
            models = 0;
            generations = 0;
            cars = 0;
            userCars = 0;

            if (make == null) return;

            models = this.context.Models
                .Count(x => x.MakeId == make.Id);

            generations = this.context.Generations
                .Count(x => x.Model.MakeId == make.Id);

            cars = this.context.Cars
                .Count(x => x.Generation.Model.MakeId == make.Id);

            userCars = this.context.UserCars
                .Count(x => x.Car.Generation.Model.MakeId == make.Id);
        }

        public async Task UpdateAsync(Make make)
        {
            if (make == null) return;

            this.context.Makes.Update(make);
            await this.context.SaveChangesAsync();
        }
    }
}
