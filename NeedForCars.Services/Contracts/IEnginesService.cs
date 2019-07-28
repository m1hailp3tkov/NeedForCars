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

        Task DeleteAsync(int engineId);
    }
}
