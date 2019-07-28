using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;

namespace NeedForCars.Services
{
    public class GenerationsService : IGenerationsService
    {
        private readonly IModelsService modelsService;
        private readonly NeedForCarsDbContext context;

        public GenerationsService(IModelsService modelsService, NeedForCarsDbContext context)
        {
            this.modelsService = modelsService;
            this.context = context;
        }

        public async Task AddAsync(Generation generation)
        {
            if (generation == null) return;

            await this.context.Generations.AddAsync(generation);
            await this.context.SaveChangesAsync();
        }

        public bool Exists(int modelId, string generationName)
        {
            var model = this.modelsService.GetById(modelId);

            return model.Generations
                .Any(x => x.Name == generationName);
        }

        public Generation GetById(int id)
        {
            return this.context
                .Generations
                .Include(x => x.Model)
                    .ThenInclude(x => x.Make)
                .Include(x => x.Cars)
                    .ThenInclude(x => x.Engine)
                .FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Generation> GetAllForModel(int modelId)
        {
            var generations = this.context
                .Models
                .Include(x => x.Generations)
                .FirstOrDefault(x => x.Id == modelId)
                .Generations
                .AsQueryable();

            return generations;
        }

        public async Task UpdateAsync(Generation generation)
        {
            if (generation == null) return;

            this.context.Generations
                .Update(generation);

            await this.context.SaveChangesAsync();
        }
    }
}
