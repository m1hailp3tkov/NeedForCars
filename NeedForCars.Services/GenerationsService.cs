using System.Collections.Generic;
using System.Linq;
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

        public void Add(Generation generation)
        {
            if (generation == null) return;

            this.context.Generations.Add(generation);
            this.context.SaveChanges();
        }

        public bool Exists(string modelId, string generationName)
        {
            var model = this.modelsService.GetById(modelId);

            return model.Generations
                .Any(x => x.Name == generationName);
        }

        public Generation GetById(string id)
        {
            return this.context
                .Generations
                .Include(x => x.Model)
                    .ThenInclude(x => x.Make)
                .Include(x => x.Cars)
                    .ThenInclude(x => x.Engine)
                .FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Generation> GetAllForModel(string modelId)
        {
            var generations = this.context
                .Models
                .Include(x => x.Generations)
                .FirstOrDefault(x => x.Id == modelId)
                .Generations
                .AsQueryable();

            return generations;
        }

        public void Update(Generation generation)
        {
            if (generation == null) return;

            this.context.Generations
                .Update(generation);

            this.context.SaveChanges();
        }
    }
}
