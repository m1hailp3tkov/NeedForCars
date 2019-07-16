﻿using System.Collections.Generic;
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

        public void AddGenerationToModel(string modelId, Generation generation)
        {
            var model = modelsService.GetById(modelId);

            model.Generations.Add(generation);

            this.context.Models.Update(model);
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
            this.context.Generations
                .Update(generation);

            this.context.SaveChanges();
        }
    }
}