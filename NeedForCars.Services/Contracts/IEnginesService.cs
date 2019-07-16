using NeedForCars.Models;
using System.Linq;

namespace NeedForCars.Services.Contracts
{
    public interface IEnginesService
    {
        IQueryable<Engine> All();

        void Add(Engine engine);

        Engine GetById(string id);

        void Update(Engine engine);

        void Delete(string engineId);
    }
}
