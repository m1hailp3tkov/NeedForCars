using NeedForCars.Models;
using System.Collections.Generic;

namespace NeedForCars.Services.Contracts
{
    public interface IModelsService
    {
        void AddModelToMake(string makeId, Model model);

        bool Exists(string makeId, string modelName);

        ICollection<Model> GetAllForMake(string makeId);
    }
}
