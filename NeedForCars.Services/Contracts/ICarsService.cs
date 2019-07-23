using NeedForCars.Models;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface ICarsService
    {
        Task AddAsync(Car car);

        bool Exists(Car car);

        Car GetById(string id);

        Task Update(Car car);
    }
}
