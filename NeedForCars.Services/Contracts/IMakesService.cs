using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IMakesService
    {
        Task AddAsync(Make make);

        bool Exists(string makeName);

        IQueryable<Make> GetAll();

        Make GetById(string id);

        Task UpdateAsync(Make make);
    }
}
