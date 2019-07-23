using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IModelsService
    {
        Task AddAsync(Model model);

        bool Exists(string makeId, string modelName);

        Model GetById(string modelId);

        IQueryable<Model> GetAllForMake(string makeId);

        Task UpdateAsync(Model model);
    }
}
