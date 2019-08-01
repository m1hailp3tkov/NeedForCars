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

        Make GetById(int id);

        Task UpdateAsync(Make make);

        Task DeleteAsync(Make make);

        void GetRelatedEntitiesCount(Make make, out int models, out int generations, out int cars, out int userCars);
    }
}
