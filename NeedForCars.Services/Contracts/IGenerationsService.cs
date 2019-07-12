using NeedForCars.Models;
using System.Collections.Generic;

namespace NeedForCars.Services.Contracts
{
    public interface IGenerationsService
    {
        void AddGenerationToModel(string modelId, Generation generation);

        bool Exists(string modelId, string generationName);

        ICollection<Generation> GetAllForModel(string modelId);

        Generation GetById(string id);

        void Update(Generation generation);
    }
}
