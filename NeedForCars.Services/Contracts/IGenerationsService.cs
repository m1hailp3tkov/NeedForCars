using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IGenerationsService
    {
        Task AddAsync(Generation generation);

        bool Exists(int modelId, string generationName);

        IQueryable<Generation> GetAllForModel(int modelId);

        Generation GetById(int id);

        Task UpdateAsync(Generation generation);

        Task DeleteAsync(Generation generation);

        void GetRelatedEntitiesCount(Generation generation, out int cars, out int userCars);
    }
}
