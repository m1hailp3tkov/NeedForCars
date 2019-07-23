using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IEnginesService
    {
        IQueryable<Engine> All();

        Task AddAsync(Engine engine);

        Engine GetById(string id);

        Task UpdateAsync(Engine engine);

        Task DeleteAsync(string engineId);
    }
}
