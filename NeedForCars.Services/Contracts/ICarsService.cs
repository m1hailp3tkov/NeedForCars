using NeedForCars.Models;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface ICarsService
    {
        Task AddAsync(Car car);

        bool Exists(Car car);

        Car GetById(int id);

        Task UpdateAsync(Car car);

        Task DeleteAsync(Car car);

        void GetRelatedEntitiesCount(Car car, out int userCars);
    }
}
