using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IGenerationsService
    {
        Task AddAsync(Generation generation);

        bool Exists(string modelId, string generationName);

        IQueryable<Generation> GetAllForModel(string modelId);

        Generation GetById(string id);

        Task UpdateAsync(Generation generation);

        //TODO: Add Delete for generations
    }
}
