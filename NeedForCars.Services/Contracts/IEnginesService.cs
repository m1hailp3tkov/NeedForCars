using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IEnginesService
    {
        IQueryable<Engine> All();

        Task AddAsync(Engine engine);

        Engine GetById(int id);

        Task UpdateAsync(Engine engine);

        Task DeleteAsync(Engine engine);

        void GetRelatedEntitiesCount(Engine engine, out int cars, out int userCars);
    }
}
