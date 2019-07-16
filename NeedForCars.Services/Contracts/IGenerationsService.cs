using NeedForCars.Models;
using System.Linq;

namespace NeedForCars.Services.Contracts
{
    public interface IGenerationsService
    {
        void AddGenerationToModel(string modelId, Generation generation);

        bool Exists(string modelId, string generationName);

        IQueryable<Generation> GetAllForModel(string modelId);

        Generation GetById(string id);

        void Update(Generation generation);
    }
}
