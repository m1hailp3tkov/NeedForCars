using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NeedForCars.Services
{
    public class ModelsService : IModelsService
    {
        private readonly NeedForCarsDbContext context;
        private readonly IMakesService makesService;

        public ModelsService(NeedForCarsDbContext context, IMakesService makesService)
        {
            this.context = context;
            this.makesService = makesService;
        }

        public async Task AddAsync(Model model)
        {
            if (model == null) return;

            await this.context.Models.AddAsync(model);
            await this.context.SaveChangesAsync();
        }

        public bool Exists(int makeId, string modelName)
        {
            var make = makesService.GetById(makeId);
            if (make == null) return false;

            return make.Models
                .Any(x => x.Name == modelName);
        }

        public Model GetById(int modelId)
        {
            return this.context
                .Models
                .Include(x => x.Make)
                .Include(x => x.Generations)
                .FirstOrDefault(x => x.Id == modelId);
        }

        public IQueryable<Model> GetAllForMake(int makeId)
        {
            var models = this.context
                .Makes
                .Include(x => x.Models)
                .FirstOrDefault(x => x.Id == makeId)
                .Models
                .AsQueryable();

            return models;
        }

        public async Task UpdateAsync(Model model)
        {
            this.context.Models.Update(model);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Model model)
        {
            if (model == null) return;

            this.context.Remove(model);
            await this.context.SaveChangesAsync();
        }

        public void GetRelatedEntitiesCount(Model model, out int generations, out int cars, out int userCars)
        {
            //TODO INCLUDE??
            generations = 0;
            cars = 0;
            userCars = 0;

            if (model == null) return;

            generations = this.context.Generations
                .Count(x => x.ModelId == model.Id);

            cars = this.context.Cars
                .Count(x => x.Generation.ModelId == model.Id);

            userCars = this.context.UserCars
                .Count(x => x.Car.Generation.ModelId == model.Id);
        }
    }
}
