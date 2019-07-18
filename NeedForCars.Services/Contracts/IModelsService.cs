using NeedForCars.Models;
using System.Linq;

namespace NeedForCars.Services.Contracts
{
    public interface IModelsService
    {
        void Add(Model model);

        bool Exists(string makeId, string modelName);

        Model GetById(string modelId);

        IQueryable<Model> GetAllForMake(string makeId);

        void Update(Model model);
    }
}
