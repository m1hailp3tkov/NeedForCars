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

        public bool Exists(string makeId, string modelName)
        {
            var make = makesService.GetById(makeId);
            if (make == null) return false;

            return make.Models
                .Any(x => x.Name == modelName);
        }

        public Model GetById(string modelId)
        {
            return this.context
                .Models
                .Include(x => x.Make)
                .Include(x => x.Generations)
                .FirstOrDefault(x => x.Id == modelId);
        }

        public IQueryable<Model> GetAllForMake(string makeId)
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
    }
}
