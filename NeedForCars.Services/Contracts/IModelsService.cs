using NeedForCars.Models;
using System.Collections.Generic;

namespace NeedForCars.Services.Contracts
{
    public interface IModelsService
    {
        void AddModelToMake(string makeId, Model model);

        bool Exists(string makeId, string modelName);

        Model GetById(string modelId);

        ICollection<Model> GetAllForMake(string makeId);

        void Update(Model model);
    }
}
