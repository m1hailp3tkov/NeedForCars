using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IModelsService
    {
        Task AddAsync(Model model);

        bool Exists(int makeId, string modelName);

        Model GetById(int modelId);

        IQueryable<Model> GetAllForMake(int makeId);

        Task UpdateAsync(Model model);
    }
}
